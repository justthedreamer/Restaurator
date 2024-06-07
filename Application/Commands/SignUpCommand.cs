using ICommand = Application.Commands.Abstraction.ICommand;

namespace Application.Commands;

public sealed record SignUpCommand(Guid UserId, string Email, string Password, string FirstName, string LastName)
    : ICommand;