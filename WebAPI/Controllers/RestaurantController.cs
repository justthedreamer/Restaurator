using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("/restaurant")]
[ApiController]
public class RestaurantController(
    IQueryHandler<GetRestaurantProfile, RestaurantProfileDto> getRestaurantProfileHandler,
    IQueryHandler<GetRestaurantMenu, MenuDto> getRestaurantMenu,
    IQueryHandler<GetRestaurantTables, IEnumerable<TableDto>> getTables)
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
        var menu = await getRestaurantMenu.HandleAsync(new GetRestaurantMenu {RestaurantId = restaurantId});
        return Ok(menu);
    }

    [HttpGet("{restaurantId:guid}/tables")]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetTables(Guid restaurantId)
    {
        var tables = await getTables.HandleAsync(new GetRestaurantTables() { RestaurantId = restaurantId });
        return Ok(tables);
    }
}