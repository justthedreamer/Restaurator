using Core.Exceptions.Schedule;

namespace Core.ValueObject.Schedule;

public sealed record ScheduleState
{
    public const string WaitingForApproval = "WAITING FOR APPROVAL";
    public const string Confirmed = "CONFIRED";
    public const string ConfirmedWithChanges = "CONFIRMED WITH CHANGES";
    public const string Rejected = "REJECTED";

    public string Value { get; }

    public ScheduleState(string value)
    {
        var isValid = value == WaitingForApproval || value == Confirmed || value == ConfirmedWithChanges ||
                      value == Rejected;
        if (!isValid)
        {
            throw new InvalidScheduleStateException(value);
        }

        Value = value;
    }

    public static implicit operator ScheduleState(string value) => new(value);
    public static implicit operator string(ScheduleState scheduleState) => scheduleState.Value;
}