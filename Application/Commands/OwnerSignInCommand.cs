using Application.Commands.Abstraction;

namespace Application.Commands;

/// <summary>
/// Represent owner sign in action command
/// </summary>
/// <param name="Email">Email address</param>
/// <param name="Password">Password</param>
public sealed record OwnerSignInCommand(string Email,string Password) : ICommand;
