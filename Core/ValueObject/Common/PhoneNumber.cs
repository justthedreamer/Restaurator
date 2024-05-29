using Core.Exceptions.Common;

namespace Core.ValueObject.Common;

public sealed record PhoneNumber
{
    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidPhoneNumberException();
        }

        var notValid = value.Any(char.IsLetter);

        if (notValid)
        {
            throw new InvalidPhoneNumberException();
        }
        
        Value = value;
    }

    public static implicit operator PhoneNumber(string value) => new(value);
    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
}