using Application.Commands;
using Application.Commands.Abstraction;
using Application.DTO.User;
using Application.Queries;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_API.Utilities;

namespace Web_API.Controllers;

[Route("restaurant/{restaurantId:guid}/employees")]
[ApiController]
public class EmployeeController(
    IQueryHandler<GetRestaurantEmployees, IEnumerable<EmployeeDto>> getRestaurantEmployees,
    IQueryHandler<GetEmployeeProfile, EmployeeDto> getEmployeeProfile,
    ICommandHandler<CreateEmployee> createEmployee,
    ICommandHandler<DeleteEmployee> deleteEmployee,
    ICommandHandler<UpdateEmployeeName> updateEmployeeName,
    ICommandHandler<UpdateEmployeePosition> updateEmployeePosition,
    IQueryHandler<GetUserRole, UserRole> getUserRole)
    : ControllerBase
{
    [HttpGet]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(Guid restaurantId)
    {
        var employees = await getRestaurantEmployees.HandleAsync(new GetRestaurantEmployees(restaurantId));
        return Ok(employees);
    }

    [HttpGet("{employeeId:guid}")]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeProfile(Guid restaurantId, Guid employeeId)
    {
        var employee = await getEmployeeProfile.HandleAsync(new GetEmployeeProfile()
            { RestaurantId = restaurantId, EmployeeId = employeeId });

        return Ok(employee);
    }

    [HttpPost]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateEmployee(Guid restaurantId, CreateEmployee command)
    {
        var employeeId = Guid.NewGuid();
        await createEmployee.HandleAsync(command with { RestaurantId = restaurantId, EmployeeId = employeeId });
        return CreatedAtAction(nameof(GetEmployeeProfile), new { restaurantId = restaurantId, employeeId = employeeId },
            null);
    }

    [HttpDelete("{employeeId:guid}")]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteEmployee(Guid restaurantId, Guid employeeId)
    {
        await deleteEmployee.HandleAsync(new DeleteEmployee() { RestaurantId = restaurantId, EmployeeId = employeeId });
        return NoContent();
    }

    [HttpPatch("{employeeId:guid}/name")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [Authorize("is-owner-or-manager")]
    public async Task<IActionResult> UpdateEmployeeName(Guid restaurantId, Guid employeeId,
        UpdateEmployeeName command)
    {
        var requestingUserId = ContextHelper.GetUserId(HttpContext);
        var userRole = await getUserRole.HandleAsync(new GetUserRole() { UserId = requestingUserId });

        await updateEmployeeName.HandleAsync(command with
        {
            RestaurantId = restaurantId, EmployeeId = employeeId, RequestingUserRole = userRole
        });
        
        return AcceptedAtAction(nameof(GetEmployeeProfile),
            new { restaurantId = restaurantId, employeeId = employeeId }, null);
    }

    [HttpPatch("{employeeId:guid}/position")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateEmployeePosition(Guid restaurantId, Guid employeeId,
        UpdateEmployeePosition command)
    {
        var requestingUserId = ContextHelper.GetUserId(HttpContext);
        var userRole = await getUserRole.HandleAsync(new GetUserRole() { UserId = requestingUserId });
        
        await updateEmployeePosition.HandleAsync(command with { RestaurantId = restaurantId, EmployeeId = employeeId,RequestingUserRole = userRole});
        return AcceptedAtAction(nameof(GetEmployeeProfile),
            new { restaurantId = restaurantId, employeeId = employeeId }, null);
    }
}