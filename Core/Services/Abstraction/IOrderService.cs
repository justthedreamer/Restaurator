using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.ValueObject.Order;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

/// <summary>
/// Order service interface
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Get available states for provided order.
    /// </summary>
    /// <param name="order">Instance of <see cref="Order"/></param>
    /// <returns>Collection of <see cref="OrderState"/>></returns>
    IEnumerable<OrderState> GetAvailableStates(Order order);

    /// <summary>
    /// Change order state
    /// </summary>
    /// <param name="order">Instance of <see cref="Order"/></param>
    /// <param name="orderState">New state</param>
    void ChangeOrderState(Order order, OrderState orderState);
}