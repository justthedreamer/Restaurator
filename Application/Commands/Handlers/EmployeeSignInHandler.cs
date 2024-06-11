using System.Security.Authentication;
using Application.Abstraction;
using Application.Commands.Abstraction;
using Application.Exceptions;
using Application.Security;
using Core.Repositories;

namespace Application.Commands.Handlers;

/// <summary>
/// Represent employee sign in action handler.
/// </summary>
/// <param name="employeeRepository">Employee repository</param>
/// <param name="passwordManager">Password Manager</param>
public class EmployeeSignInHandler(IEmployeeRepository employeeRepository, IPasswordManager passwordManager,IAuthenticator authenticator,ITokenStorage tokenStorage)
    : ICommandHandler<EmployeeSignInCommand>
{
    public async Task HandleAsync(EmployeeSignInCommand command)
    {
        var employee = await employeeRepository.GetEmployeeByLoginAsync(command.Login);

        if (employee is null)
            throw new EmployeeNotFoundException();

        var isValidPassword = passwordManager.Validate(command.Password, employee.Credentials.Password);

        if (!isValidPassword)
            throw new InvalidCredentialException();

        var token = authenticator.CreateToken(employee.UserId, employee.UserRole);
        tokenStorage.Set(token);
    }
}