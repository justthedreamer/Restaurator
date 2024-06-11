using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("restaurant/{restaurantId:guid}/reservations")]
[ApiController]
public class ReservationController(
    IQueryHandler<GetRestaurantReservations, IEnumerable<ReservationDto>> getRestaurantReservation
    ) : ControllerBase
{
    [HttpGet]
    [Authorize]
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
}