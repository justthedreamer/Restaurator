using Core.Exceptions.Menu;

namespace Core.ValueObject.Menu;

public sealed record PrepareTime
{
    public string Value { get; private set; }

    public PrepareTime(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidPrepareTimeException();
        }

        Value = value;
    }

    public static implicit operator PrepareTime(string value) => new(value);
    public static implicit operator string(PrepareTime prepareTime) => prepareTime.Value;
}