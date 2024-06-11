using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public class GetDeliveryOrder : IQuery<DeliveryOrderDto>
{
    public Guid RestaurantId { get; set; }
    public Guid OrderId { get; set; }
}