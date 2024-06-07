using Core.Exceptions.Restaurant;

namespace Core.ValueObject.Restaurant;

public sealed record TableSign
{
    public string Value { get; }

    public TableSign(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidTableSignException();
        Value = value;
    }

    public static implicit operator TableSign(string value) => new(value);
    public static implicit operator string(TableSign tableSign) => tableSign.Value;
}