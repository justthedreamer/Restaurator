using Core.Exceptions.Schedule;

namespace Core.ValueObject.Schedule;

/// <summary>
/// Represents employee schedule date
/// </summary>
public class EmployeeScheduleDate
{
    public TimeOnly Value { get; }

    public EmployeeScheduleDate(TimeOnly value)
    {
        if (value.Second != 0 || value.Millisecond != 0 || value.Microsecond != 0)
        {
            throw new InvalidScheduleDateException("Schedule date should be total.");
        }

        Value = value;
    }

    public static implicit operator EmployeeScheduleDate(TimeOnly value) => new(value);
    public static implicit operator TimeOnly(EmployeeScheduleDate employeeScheduleDate) => employeeScheduleDate.Value;

    public static bool operator >(EmployeeScheduleDate date1, EmployeeScheduleDate date2) => date1.Value > date2.Value;
    public static bool operator <(EmployeeScheduleDate date1, EmployeeScheduleDate date2) => date1.Value < date2.Value;
}