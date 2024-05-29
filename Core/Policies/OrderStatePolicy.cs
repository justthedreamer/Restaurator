using Core.Model.OrderModel;
using Core.Policies.Abstraction;
using Core.ValueObject.Order;

namespace Core.Policies;

/// <summary>
/// Order state policy
/// </summary>
internal class OrderStatePolicy : IOrderStatePolicy
{
    /// <summary>
    /// States map
    /// </summary>
    private readonly Dictionary<OrderState, OrderState[]> _availableStatesMap = new()
    {
        {OrderState.WaitingForApproval, [OrderState.InProgress,OrderState.Cancelled,OrderState.Rejected,] },
        {OrderState.InProgress, [OrderState.Ready, OrderState.Cancelled] },
        {OrderState.Ready,[OrderState.WaitingForCustomer,OrderState.InDelivery,OrderState.Cancelled ,OrderState.Completed]},
        {OrderState.WaitingForCustomer,[OrderState.Completed,OrderState.NotTaken,OrderState.Rejected]},
        {OrderState.NotTaken,[OrderState.Completed,]},
        {OrderState.InDelivery,[OrderState.Delivered] },
        {OrderState.Cancelled,[OrderState.InProgress]},
        {OrderState.Rejected,[OrderState.InProgress]},
        {OrderState.Completed,[]},
        {OrderState.Delivered,[]},
    };

    /// <summary>
    /// Verify if order state could be changed.
    /// </summary>
    /// <param name="order">Order</param>
    /// <param name="orderState">New order state</param>
    /// <returns>True or false</returns>
    public bool CanApply(Order order, OrderState orderState)
    {
        var isAvailable = _availableStatesMap[order.OrderState].Any(x => x == orderState);
        return isAvailable;
    }

    /// <summary>
    /// Get available states
    /// </summary>
    /// <param name="order">Order</param>
    /// <returns>List of available states for provided order.</returns>
    public IEnumerable<OrderState> GetAvailableStates(Order order) => _availableStatesMap[order.OrderState].AsEnumerable();
}