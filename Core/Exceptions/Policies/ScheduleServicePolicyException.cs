using Core.Exceptions.User;

namespace Core.Exceptions.Policies;

public class ScheduleServicePolicyException(string message) : BadRequestException(message);
