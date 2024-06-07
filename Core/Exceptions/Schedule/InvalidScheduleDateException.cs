using Core.Exceptions.User;

namespace Core.Exceptions.Schedule;

public class InvalidScheduleDateException(string message) : BadRequestException(message);
