using Core.ValueObject.Schedule;

namespace Core.Exceptions.Schedule;

public class InvalidEmployeeScheduleTimeSpanException(EmployeeScheduleDate workFrom, EmployeeScheduleDate workTo) : CustomException($"Invalid schedule time span : {workFrom}, {workTo}");