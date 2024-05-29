namespace Core.Exceptions.Policies;

public class ScheduleServicePolicyException(string message) : CustomException(message);
