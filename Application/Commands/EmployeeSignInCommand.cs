using Application.Commands.Abstraction;

namespace Application.Commands;

public sealed record EmployeeSignInCommand(string Login, string Password) : ICommand;