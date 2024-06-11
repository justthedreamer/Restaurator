using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public sealed record GetTakeAwayOrders : IQuery<IEnumerable<TakeAwayOrderDto>>
{
    public Guid RestaurantId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}