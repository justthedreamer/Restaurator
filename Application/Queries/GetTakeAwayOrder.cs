using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public class GetTakeAwayOrder : IQuery<TakeAwayOrderDto>
{
    public Guid RestaurantId { get; set; }
    public Guid OrderId { get; set; }
}