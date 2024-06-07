using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Application.DTO.User;

public sealed class EmployeeDto
{
    public required UserId EmployeeId { get; init; }
    public required EmployeeLogin Login { get; init; }
    public required FirstName FirstName { get; init; }
    public required LastName LastName { get; init; }
    public required EmployeePosition Position { get; init; }
    public required UserRole Role { get; init; }
}