namespace Core.ValueObject.Schedule;

public sealed record EmployeeScheduleId
{
    public Guid Value { get; }

    public EmployeeScheduleId(Guid value)
    {
        Value = value;
    }

    public static implicit operator EmployeeScheduleId(Guid value) => new(value);
    public static implicit operator Guid(EmployeeScheduleId employeeScheduleId) => employeeScheduleId.Value;
}