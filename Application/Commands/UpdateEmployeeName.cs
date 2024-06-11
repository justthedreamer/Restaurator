using Application.Commands.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Commands;

public sealed record UpdateEmployeeName : ICommand
{
    public Guid RestaurantId { get; set; }
    public Guid EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public UserRole RequestingUserRole { get; set; } = default!;
}