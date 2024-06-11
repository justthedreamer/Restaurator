using Application.DTO;
using Application.Queries.Abstraction;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantOrders(Guid RestaurantId, DateTime? From, DateTime? To)
    : IQuery<IEnumerable<RestaurantOrderDto>>
{
}