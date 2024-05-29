using Core.Exceptions.Order;

namespace Core.ValueObject.Order;

public sealed record OrderType
{
    public const string DeliveryOrder = "DELIVERY ORDER";
    public const string RestaurantOrder = "RESTAURANT ORDER";
    public const string TakeAwayOrder = "TAKE AWAY ORDER";
    
    public string Value { get; }

    public OrderType(string value)
    {
        var isValid = value == DeliveryOrder || value == RestaurantOrder || value == TakeAwayOrder;

        if (!isValid)
        {
            throw new InvalidOrderTypeException(value);
        }
        
        Value = value;
    }

    public static implicit operator OrderType(string value) => new(value);
    public static implicit operator string(OrderType orderType) => orderType.Value;

}