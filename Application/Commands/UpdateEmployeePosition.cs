using Application.Commands.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Commands;

public sealed record UpdateEmployeePosition : ICommand
{
    public Guid RestaurantId { get; set; }
    public Guid EmployeeId { get; set; }
    public required string Position { get; set; }
    public UserRole RequestingUserRole { get; set; } = default!;
}