namespace Core.Exceptions.Schedule;

public class InvalidScheduleStateException(string value) : CustomException($"Invalid schedule state {value}");
