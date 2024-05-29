using Core.Exceptions.Staff;

namespace Core.ValueObject.Staff.Employee;

public sealed record FirstName
{
    public string Value { get; }

    public FirstName(string value)
    {
        var t = value.Trim();

        if (string.IsNullOrEmpty(t))
        {
            throw new InvalidFirstNameException("First Name cannot be empty.");
        }

        if (!IsLetterOnly(t))
        {
            throw new InvalidFirstNameException("First Name should contains only letters.");
        }

        Value = t;
    }

    private static bool IsLetterOnly(string value) => value.All(char.IsLetter);

    public static implicit operator FirstName(string value) => new(value);
    public static implicit operator string(FirstName firstName) => firstName.Value;
};