namespace Core.ValueObject.Schedule;

public record DailyEmployeeScheduleId
{
    public Guid Value { get; }

    public DailyEmployeeScheduleId(Guid value)
    {
        Value = value;
    }

    public static implicit operator DailyEmployeeScheduleId(Guid value) => new(value);

    public static implicit operator Guid(DailyEmployeeScheduleId dailyEmployeeScheduleId) =>
        dailyEmployeeScheduleId.Value;
}