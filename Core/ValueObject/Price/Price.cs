using Core.Exceptions.Price;

namespace Core.ValueObject.Price;

public sealed record Price
{
    public double Value { get; }

    public Price(double value)
    {
        if (value < 0)
        {
            throw new InvalidPriceException(value);
        }
        Value = value;
    }

    public static implicit operator Price(double value) => new(value);
    public static implicit operator double(Price price) => price.Value;
}