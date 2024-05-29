using Core.Exceptions.Restaurant;

namespace Core.ValueObject.Restaurant;

public sealed record SeatsCount
{
    public ushort Value { get; }

    public SeatsCount(ushort value)
    {
        if (value == 0)
        {
            throw new InvalidSeatsCountException(value);
        }

        Value = value;
    }

    public static implicit operator SeatsCount(ushort value) => new(value);
    public static implicit operator ushort(SeatsCount seatsCount) => seatsCount.Value;
}