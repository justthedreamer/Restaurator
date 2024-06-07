using Application.DTO;
using Application.Queries.Abstraction;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantReservations(Guid RestaurantId, DateTime? From, DateTime? To)
    : IQuery<IEnumerable<ReservationDto>>
{
}