using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public class GetRestaurantOrder : IQuery<RestaurantOrderDto>
{
    public Guid RestaurantId { get; set; }
    public Guid OrderId { get; set; }
}