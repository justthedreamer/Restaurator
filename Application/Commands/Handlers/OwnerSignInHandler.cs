using System.Security.Authentication;
using Application.Abstraction;
using Application.Commands.Abstraction;
using Application.Exceptions;
using Application.Security;
using Core.Repositories;

namespace Application.Commands.Handlers;

public class OwnerSignInHandler(
    IOwnerRepository ownerRepository,
    IPasswordManager passwordManager,
    IAuthenticator authenticator,
    ITokenStorage tokenStorage) : ICommandHandler<OwnerSignInCommand>
{
    public async Task HandleAsync(OwnerSignInCommand command)
    {
        var owner = await ownerRepository.GetOwnerByEmailAsync(command.Email);

        if (owner is null)
            throw new UserNotFoundException();

        var isPasswordValid = passwordManager.Validate(command.Password, owner.Credentials.Password);

        if (!isPasswordValid)
            throw new InvalidCredentialException();

        var token = authenticator.CreateToken(owner.UserId, owner.UserRole);
        tokenStorage.Set(token);
    }
}