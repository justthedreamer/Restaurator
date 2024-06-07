using Core.Exceptions.User;

namespace Core.Exceptions.Schedule;

public class InvalidScheduleStateException(string value) : BadRequestException($"Invalid schedule state {value}");
