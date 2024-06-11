using Application.Commands;
using Application.Commands.Abstraction;
using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("/restaurant/{restaurantId:guid}/schedules")]
[ApiController]
public class ScheduleController(
    IQueryHandler<GetRestaurantSchedules, IEnumerable<DailyEmployeeScheduleDto>> getRestaurantSchedules,
    IQueryHandler<GetDailySchedule, DailyEmployeeScheduleDto> getDailySchedule,
    ICommandHandler<CreateDailySchedule> createDailySchedule,
    ICommandHandler<CreateEmployeeSchedule> createEmployeeSchedule) : ControllerBase
{
    [HttpGet]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<DailyEmployeeScheduleDto>>> GetSchedules(Guid restaurantId, DateOnly from, DateOnly to)
    {
        var query = new GetRestaurantSchedules()
        {
            RestaurantId = restaurantId,
            From = from,
            To = to
        };
        var schedules = await getRestaurantSchedules.HandleAsync(query);

        return Ok(schedules);
    }

    [HttpGet("daily-schedules/{scheduleId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<DailyEmployeeScheduleDto>> GetDailySchedule(Guid restaurantId, Guid scheduleId)
    {
        var query = new GetDailySchedule()
        {
            RestaurantId = restaurantId,
            ScheduleId = scheduleId
        };

        var schedule = await getDailySchedule.HandleAsync(query);
        return Ok(schedule);
    }

    [HttpPost("daily-schedules")]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateDailySchedule(CreateDailySchedule command)
    {
        var scheduleId = Guid.NewGuid();
        await createDailySchedule.HandleAsync(command with { ScheduleId = scheduleId });
        return CreatedAtAction(nameof(GetDailySchedule), new
        {
            restaurantId = command.RestaurantId,
            scheduleId = scheduleId
        });
    }

    [HttpPost("employee-schedules")]
    [Authorize("is-owner-or-manager")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> CreateEmployeeSchedule(CreateEmployeeSchedule command)
    {
        var scheduleId = Guid.NewGuid();
        await createEmployeeSchedule.HandleAsync(command with { ScheduleId = scheduleId });
        return CreatedAtAction(nameof(GetDailySchedule), new
        {
            restaurantId = command.RestaurantId,
            scheduleId = scheduleId
        });
    }
}