using Core.Exceptions.Order;

namespace Core.ValueObject.Order;

/// <summary>
/// Represent order state
/// </summary>
public sealed record OrderState
{
    public const string WaitingForApproval = "WAITING FOR APPROVAL";
    public const string Cancelled = "CANCELLED";
    public const string Rejected = "REJECTED";

    public const string InProgress = "IN PROGRESS";
    public const string Ready = "READY";
    public const string WaitingForCustomer = "WAITING FOR CUSTOMER";
    public const string NotTaken = "NOT TAKEN BY CUSTOMER";
    public const string Completed = "COMPLETED";

    public const string InDelivery = "IN DELIVERY";
    public const string Delivered = "DELIVERED";

    public string Value { get; private set; }

    public OrderState(string value)
    {
        var isValid = value == WaitingForApproval || value == Cancelled || value == Rejected || value == InProgress || value == Ready || value == WaitingForCustomer || value == NotTaken || value == Completed || value == InDelivery || value == Delivered;

        if (!isValid)
            throw new InvalidOrderStateException(value, null);

        Value = value;
    }

    public static implicit operator OrderState(string value) => new(value);
    public static implicit operator string(OrderState orderState) => orderState.Value;
}