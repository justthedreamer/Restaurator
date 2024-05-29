using Core.Exceptions.Staff;

namespace Core.ValueObject.Staff.Employee;

public sealed record EmployeePosition
{
    public const string Manager = "MANAGER";
    public const string Chef = "CHEF";
    public const string Waiter = "WAITER";
    public const string Bartender = "BARTENDER";
    public const string DeliveryMan = "DELIVERY MAN";
    public const string Cleaner = "CLEANER";

    public string Value { get; }
    
    public EmployeePosition(string value)
    {
        var isValid = value == Chef || value == Waiter || value == Bartender || value == DeliveryMan ||
                      value == Cleaner || value == Manager;
        if (!isValid)
        {
            throw new InvalidEmployeePositionException();
        }

        Value = value;
    }

    public static implicit operator EmployeePosition(string value) => new(value);
    public static implicit operator string(EmployeePosition employeePosition) => employeePosition.Value;
}