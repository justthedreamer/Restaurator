using Core.ValueObject.Order;

namespace Core.Exceptions.Policies;

public class OrderStatePolicyException(OrderState orderState, string availableStates) : CustomException($"Invalid state : {orderState}.Available states : {availableStates}");
