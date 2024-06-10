using Application.Commands;
using Application.Commands.Abstraction;
using Application.DTO;
using Application.DTO.User;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("/restaurant")]
[ApiController]
public class RestaurantController(
    IQueryHandler<GetRestaurantProfile, RestaurantProfileDto> getRestaurantProfileHandler,
    IQueryHandler<GetRestaurantEmployees, IEnumerable<EmployeeDto>> getRestaurantEmployees,
    IQueryHandler<GetRestaurantMenu, MenuDto> getRestaurantMenu,
    IQueryHandler<GetRestaurantOrders, IEnumerable<OrderDto>> getRestaurantOrders,
    IQueryHandler<GetRestaurantReservations, IEnumerable<ReservationDto>> getRestaurantReservation,
    IQueryHandler<GetRestaurantSchedules, IEnumerable<DailyEmployeeScheduleDto>> getRestaurantSchedules,
    IQueryHandler<GetDailySchedule, DailyEmployeeScheduleDto> getDailySchedule,
    IQueryHandler<GetRestaurantTables, IEnumerable<TableDto>> getTables,
    ICommandHandler<CreateDailySchedule> createDailySchedule,
    ICommandHandler<CreateEmployeeSchedule> createEmployeeSchedule,
    ICommandHandler<CreateRestaurantOrder> createRestaurantOrder)
    : ControllerBase
{
    [HttpGet("{restaurantId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetProfile(Guid restaurantId)
    {
        var profile = await getRestaurantProfileHandler.HandleAsync(new GetRestaurantProfile(restaurantId));

        return Ok(profile);
    }

    [HttpGet("{restaurantId:guid}/menu")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetMenu(Guid restaurantId)
    {
        var menu = await getRestaurantMenu.HandleAsync(new GetRestaurantMenu(restaurantId));
        return Ok(menu);
    }

    [HttpGet("{restaurantId:guid}/employees")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetEmployees(Guid restaurantId)
    {
        var employees = await getRestaurantEmployees.HandleAsync(new GetRestaurantEmployees(restaurantId));
        return Ok(employees);
    }

    [HttpGet("{restaurantId:guid}/orders/restaurant")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetRestaurantOrders(
        Guid restaurantId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to)
    {
        var orders = await getRestaurantOrders.HandleAsync(new GetRestaurantOrders(restaurantId, from, to));

        return Ok(orders);
    }

    [HttpPost("{restaurantId:guid}/orders/restaurant")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRestaurantOrders(Guid restaurantId,CreateRestaurantOrder command)
    {
        var orderId = Guid.NewGuid();
        await createRestaurantOrder.HandleAsync(command with { OrderId = orderId, RestaurantId = restaurantId});
        return CreatedAtAction(nameof(GetRestaurantOrders),new { restaurantId = command.RestaurantId },null);
    }

    [HttpGet("{restaurantId:guid}/reservations")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetReservations(
        Guid restaurantId,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to)
    {
        var reservations =
            await getRestaurantReservation.HandleAsync(new GetRestaurantReservations(restaurantId, from, to));

        return Ok(reservations);
    }

    [HttpGet("{restaurantId:guid}/schedules")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> GetSchedules(Guid restaurantId, DateOnly from, DateOnly to)
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

    [HttpGet("{restaurantId:guid}/daily-schedules/{scheduleId:guid}")]
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

    [HttpPost("{restaurantId:guid}/daily-schedules")]
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

    [HttpPost("{restaurantId:guid}/employee-schedules")]
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

    [HttpGet("{restaurantId:guid}/tables")]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetTables(Guid restaurantId)
    {
        var tables = await getTables.HandleAsync(new GetRestaurantTables() { RestaurantId = restaurantId });
        return Ok(tables);
    }
}