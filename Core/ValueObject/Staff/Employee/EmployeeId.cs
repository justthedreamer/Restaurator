namespace Core.ValueObject.Staff.Employee;

public record EmployeeId
{
    public Guid Value { get; }

    public EmployeeId(Guid value)
    {
        Value = value;
    }

    public static implicit operator EmployeeId(Guid value) => new(value);
    public static implicit operator Guid(EmployeeId employeeId) => employeeId.Value;

}