using Core.Exceptions.Schedule;

namespace Core.ValueObject.Schedule;

/// <summary>
/// Represents daily schedule date.
/// </summary>
/// <param name="Value"></param>
public sealed record DailyScheduleDate(DateOnly Value)
{
    public static implicit operator DailyScheduleDate(DateOnly value) => new(value);
    public static implicit operator DateOnly(DailyScheduleDate dailyScheduleDate) => dailyScheduleDate.Value;

    public static bool operator <(DailyScheduleDate date1, DailyScheduleDate date2) => date1.Value < date2.Value;
    public static bool operator >(DailyScheduleDate date1, DailyScheduleDate date2) => date1.Value > date2.Value;
}