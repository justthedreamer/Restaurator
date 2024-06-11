using Core.Model.OrderModel;
using Core.ValueObject.Order;

namespace Core.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetOrderAsync(OrderId orderId);
    Task UpdateOrderAsync(Order order);
    Task UpdateRestaurantOrderAsync(RestaurantOrder order);
    Task UpdateTakeAwayOrderAsync(TakeAwayOrder order);
    Task UpdateDeliveryOrderAsync(DeliveryOrder order);
}