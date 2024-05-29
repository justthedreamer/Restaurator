using Core.Exceptions.Staff;

namespace Core.ValueObject.Staff.Employee;

public sealed record EmployeeLogin
{
    public string Value { get; }

    public EmployeeLogin(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidEmployeeLoginException();
        Value = value;
    }

    public static implicit operator EmployeeLogin(string value) => new(value);
    public static implicit operator string(EmployeeLogin employeeLogin) => employeeLogin.Value;
}