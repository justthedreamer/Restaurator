using Core.Exceptions.Restaurant;

namespace Core.ValueObject.Restaurant;

public sealed record RestaurantName
{
    public string Value { get; }

    public RestaurantName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidRestaurantNameException();
        Value = value;
    }

    public static implicit operator RestaurantName(string value) => new(value);
    public static implicit operator string(RestaurantName restaurantName) => restaurantName.Value;

}