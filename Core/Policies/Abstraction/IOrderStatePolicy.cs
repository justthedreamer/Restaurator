using Core.Model.OrderModel;
using Core.ValueObject.Order;
using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Order state policy interface
/// </summary>
internal interface IOrderStatePolicy
{

    /// <summary>
    /// Verify if order state could be changed.
    /// </summary>
    /// <param name="order">Order</param>
    /// <param name="orderState">New order state</param>
    /// <returns>True or false</returns>
    bool CanApply(Order order, OrderState orderState);

    /// <summary>
    /// Get available states
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>List of available states for provided order.</returns>
    IEnumerable<OrderState> GetAvailableStates(Order order);
}