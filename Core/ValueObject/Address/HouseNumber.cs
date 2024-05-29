using Core.Exceptions.Address;

namespace Core.ValueObject.Address;

public record HouseNumber
{
    public string Value { get; private set; }

    public HouseNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidHouseNumberException();

        Value = value;
    }

    public static implicit operator HouseNumber(string value) => new(value);
    public static implicit operator string(HouseNumber houseNumber) => houseNumber.Value;
}