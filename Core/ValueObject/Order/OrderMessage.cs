namespace Core.ValueObject.Order;

public record OrderMessage
{
    public string Value { get; set; }

    public OrderMessage(string value)
    {
        Value = value;
    }

    public static implicit operator OrderMessage(string value) => new(value);
    public static implicit operator string(OrderMessage orderMessage) => orderMessage.Value;
}