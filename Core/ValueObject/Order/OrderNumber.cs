namespace Core.ValueObject.Order;

public sealed record OrderNumber
{
    public uint Value { get; }

    public OrderNumber(uint value)
    {
        Value = value;
    }

    public static implicit operator OrderNumber(uint value) => new(value);
    public static implicit operator uint(OrderNumber orderNumber) => orderNumber.Value;

}