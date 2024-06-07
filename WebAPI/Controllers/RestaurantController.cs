using Application.DTO;
using Application.DTO.User;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("/restaurant")]
[ApiController]
public class RestaurantController(
    IQueryHandler<GetRestaurantProfile, RestaurantProfileDto> getRestaurantProfileHandler,
    IQueryHandler<GetRestaurantEmployees, IEnumerable<EmployeeDto>> getRestaurantEmployees,
    IQueryHandler<GetRestaurantMenu, MenuDto> getRestaurantMenu,
    IQueryHandler<GetRestaurantOrders, IEnumerable<OrderDto>> getRestaurantOrders,
    IQueryHandler<GetRestaurantReservations, IEnumerable<ReservationDto>> getRestaurantReservation)
    : ControllerBase
{
    [HttpGet("{restaurantId:guid}")]
    public async Task<IActionResult> GetProfile(Guid restaurantId)
    {
        var profile = await getRestaurantProfileHandler.HandleAsync(new GetRestaurantProfile(restaurantId));

        return Ok(profile);
    }

    [HttpGet("{restaurantId:guid}/menu")]
    public async Task<IActionResult> GetMenu(Guid restaurantId)
    {
        var menu = await getRestaurantMenu.HandleAsync(new GetRestaurantMenu(restaurantId));
        return Ok(menu);
    }

    [HttpGet("{restaurantId:guid}/employees")]
    public async Task<IActionResult> GetEmployees(Guid restaurantId)
    {
        var employees = await getRestaurantEmployees.HandleAsync(new GetRestaurantEmployees(restaurantId));
        return Ok(employees);
    }

    [HttpGet("{restaurantId:guid}/orders")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(
        Guid restaurantId, 
        [FromQuery] string? orderType, 
        [FromQuery] DateTime? from, 
        [FromQuery] DateTime? to)
    {
        var orders = await getRestaurantOrders.HandleAsync(new GetRestaurantOrders(restaurantId, orderType, from, to));

        return Ok(orders);
    }


    [HttpGet("{restaurantId:guid}/reservations")]
    public async Task<IActionResult> GetReservations(
        Guid restaurantId, 
        [FromQuery] DateTime? from, 
        [FromQuery] DateTime? to)
    {
        var reservations = await getRestaurantReservation.HandleAsync(new GetRestaurantReservations(restaurantId, from, to));

        return Ok(reservations);
    }

}