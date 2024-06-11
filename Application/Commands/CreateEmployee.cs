using Application.Commands.Abstraction;

namespace Application.Commands;

public sealed record CreateEmployee : ICommand
{
    public Guid RestaurantId { get; set; }
    public Guid EmployeeId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string PhoneNumber { get; set; }
}
