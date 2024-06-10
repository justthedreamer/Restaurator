using Core.Exceptions.Price;

namespace Core.ValueObject.Price;

public sealed record Price
{
    public decimal Value { get; }

    public Price(decimal value)
    {
        if (value < 0)
        {
            throw new InvalidPriceException(value);
        }
        Value = value;
    }

    public static implicit operator Price(decimal value) => new(value);
    public static implicit operator decimal(Price price) => price.Value;
}