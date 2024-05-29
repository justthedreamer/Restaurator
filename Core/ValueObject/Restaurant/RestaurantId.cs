namespace Core.ValueObject.Restaurant;

public sealed record RestaurantId
{
    public Guid Value { get; }

    public RestaurantId(Guid value)
    {
        Value = value;
    }

    public static implicit operator RestaurantId(Guid value) => new(value);
    public static implicit operator Guid(RestaurantId restaurantId) => restaurantId.Value;
}