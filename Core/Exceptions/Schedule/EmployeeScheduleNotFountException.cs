using Core.ValueObject.Schedule;

namespace Core.Exceptions.Schedule;

public class EmployeeScheduleNotFountException(EmployeeScheduleId id) : NotFoundException($"Cannot find employee schedule with provided ID : {id}");