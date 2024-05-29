namespace Core.ValueObject.Order;

public sealed record OrderId
{
    public Guid Value { get; private set; }

    public OrderId(Guid value)
    {
        Value = value;
    }

    public static implicit operator OrderId(Guid value) => new(value);
    public static implicit operator Guid(OrderId orderId) => orderId.Value;
}