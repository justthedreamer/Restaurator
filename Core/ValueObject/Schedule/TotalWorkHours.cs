using Core.Exceptions.Schedule;

namespace Core.ValueObject.Schedule;

public sealed record TotalWorkHours
{
    public ushort Value { get; }

    public TotalWorkHours(ushort value)
    {
        if (value == 0)
        {
            throw new InvalidTotalWorkHoursException();
        }
        Value = value;
    }

    public static implicit operator TotalWorkHours(int value) => new(value);
    public static implicit operator int(TotalWorkHours totalWorkHours) => totalWorkHours.Value;
}