using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public class GetDeliveryOrders : IQuery<IEnumerable<DeliveryOrderDto>>
{
    public Guid RestaurantId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}