using Application.Commands.Abstraction;
using Application.Exceptions;
using Application.Security;
using Core.Model.StaffModel;
using Core.Repositories;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

public class SignUpHandler(IOwnerRepository ownerRepository, IPasswordManager passwordManager)
    : ICommandHandler<SignUpCommand>
{
    public async Task HandleAsync(SignUpCommand command)
    {
        var existingOwner = ownerRepository.GetOwnerByEmailAsync(command.Email);


        if (existingOwner is not null)
            throw new AccountAlreadyExist(command.Email);

        var password = passwordManager.Secure(new Password(command.Password));

        var owner = new Owner(command.UserId, UserRole.Owner, command.FirstName, command.LastName,
            new Credentials(command.Email, command.Password));

        await ownerRepository.RegisterAccountAsync(owner);
    }
}