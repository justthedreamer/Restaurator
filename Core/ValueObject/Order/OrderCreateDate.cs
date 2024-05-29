namespace Core.ValueObject.Order;

public sealed record OrderCreateDate
{
    public DateTime Value { get; private set; }

    public OrderCreateDate(DateTime value)
    {
        Value = value;
    }

    public static implicit operator OrderCreateDate(DateTime value) => new(value);
    public static implicit operator DateTime(OrderCreateDate orderCreateDate) => orderCreateDate.Value;
}