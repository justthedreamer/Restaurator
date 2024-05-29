using Core.ValueObject.Schedule;

namespace Core.Exceptions.Schedule;

public class EmployeeScheduleNotFountException(EmployeeScheduleId id) : CustomException($"Cannot find employee schedule with provided ID : {id}");