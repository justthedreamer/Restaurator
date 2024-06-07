using Core.Exceptions.User;
using Core.ValueObject.Order;

namespace Core.Exceptions.Policies;

public class OrderStatePolicyException(OrderState orderState, string availableStates) : BadRequestException($"Invalid state : {orderState}.Available states : {availableStates}");
