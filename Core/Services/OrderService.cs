using Core.Exceptions.Policies;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Order;


namespace Core.Services;

/// <summary>
/// Order state implementation
/// </summary>
/// <param name="orderStatePolicy"></param>
internal class OrderService(IOrderStatePolicy orderStatePolicy) : IOrderService
{
    /// <summary>
    /// Get available states for provided order.
    /// </summary>
    /// <param name="order">Instance of <see cref="Order"/></param>
    /// <returns>Collection of <see cref="OrderState"/>></returns>
    public IEnumerable<OrderState> GetAvailableStates(Order order) => orderStatePolicy.GetAvailableStates(order);

    /// <summary>
    /// Change order state
    /// </summary>
    /// <param name="order">Instance of <see cref="Order"/></param>
    /// <param name="orderState">New state</param>
    public void ChangeOrderState(Order order, OrderState orderState)
    {
        var canApply = orderStatePolicy.CanApply(order, orderState);

        if (!canApply)
        {
            var availableStates = orderStatePolicy.GetAvailableStates(order).Select(x => x.Value);
            throw new OrderStatePolicyException(orderState, string.Join(',', availableStates));
        }

        order.ChangeOrderState(orderState);
    }

}