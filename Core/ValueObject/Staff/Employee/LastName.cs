using Core.Exceptions.Staff;

namespace Core.ValueObject.Staff.Employee;

public sealed class LastName
{
    public string Value { get; }

    public LastName(string value)
    {
        var t = value.Trim();

        if (string.IsNullOrEmpty(t))
        {
            throw new InvalidLastNameException("Last Name cannot be empty.");
        }

        if (!IsLetterOnly(t))
        {
            throw new InvalidLastNameException("Last Name should contains only letters.");
        }

        Value = t;
    }

    private static bool IsLetterOnly(string value) => value.All(char.IsLetter);

    public static implicit operator LastName(string value) => new(value);
    public static implicit operator string(LastName lastName) => lastName.Value;
}