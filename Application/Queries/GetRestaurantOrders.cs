using Application.DTO;
using Application.Queries.Abstraction;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantOrders(Guid RestaurantId, string? OrderType, DateTime? From, DateTime? To)
    : IQuery<IEnumerable<OrderDto>>
{
}