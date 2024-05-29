using Core.Exceptions.Address;

namespace Core.ValueObject.Address;

public sealed record City
{
    public string Value { get; }

    public City(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidCityException();
        }

        Value = value;
    }

    public static implicit operator City(string value) => new(value);
    public static implicit operator string(City city) => city.Value;
}