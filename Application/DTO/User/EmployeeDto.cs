using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Application.DTO.User;

public sealed class EmployeeDto
{
    public required Guid EmployeeId { get; init; }
    public required string Login { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Position { get; init; }
    public required string Role { get; init; }
}