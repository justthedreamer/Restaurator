using Core.Exceptions;

namespace Application.Exceptions;

public class EmployeeNotFoundException() : NotFoundException("Employee not found.");
