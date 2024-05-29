using Core.Exceptions.Address;

namespace Core.ValueObject.Address;

public sealed record Street
{
    public string Value { get; }

    public Street(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidStreetException();
        }

        Value = value;
    }

    public static implicit operator Street(string value) => new(value);
    public static implicit operator string(Street street) => street.Value;
}