using Core.Exceptions.Reservation;

namespace Core.ValueObject.Reservation;

public sealed record CustomerCount
{
    public ushort Value { get; }

    public CustomerCount(ushort value)
    {
        if (value <= 0)
            throw new InvalidCustomerCountException();
        Value = value;
    }

    public static implicit operator CustomerCount(ushort value) => new(value);
    public static implicit operator ushort(CustomerCount customerCount) => customerCount.Value;
}