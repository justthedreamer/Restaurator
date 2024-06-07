using Core.Exceptions.User;

namespace Core.ValueObject.Staff.User;

public sealed record UserRole
{
    public const string Owner = "OWNER";
    public const string Manager = "MANAGER";
    public const string Employee = "EMPLOYEE";

    public string Value { get; }

    public UserRole(string value)
    {
        var isValid = value == Owner || value == Manager || value == Employee;
        if (!isValid)
        {
            throw new InvalidUserRoleException(value);
        }

        Value = value;
    }

    public static implicit operator UserRole(string value) => new(value);
    public static implicit operator string(UserRole userRole) => userRole.Value;
}