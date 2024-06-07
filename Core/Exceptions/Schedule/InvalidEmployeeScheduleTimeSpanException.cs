using Core.Exceptions.User;
using Core.ValueObject.Schedule;

namespace Core.Exceptions.Schedule;

public class InvalidEmployeeScheduleTimeSpanException(EmployeeScheduleDate workFrom, EmployeeScheduleDate workTo) : BadRequestException($"Invalid schedule time span : {workFrom}, {workTo}");