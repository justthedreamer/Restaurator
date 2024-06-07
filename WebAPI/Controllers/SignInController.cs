using System.Security.Authentication;
using Application.Abstraction;
using Application.Commands;
using Application.Commands.Abstraction;
using Application.DTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[ApiController]
[Route("sign-in")]
public class SignInController
    (ICommandHandler<EmployeeSignInCommand> employeeSignInHandler,ICommandHandler<OwnerSignInCommand> ownerSignInHandler,ITokenStorage tokenStorage)
    : ControllerBase
{

    [HttpPost("employee")]
    public async Task<ActionResult<JwtDto>> SignInEmployee(EmployeeSignInCommand command)
    {
        try
        {
            await employeeSignInHandler.HandleAsync(command);
        }
        catch (EmployeeNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidCredentialException)
        {
            return Unauthorized();
        }

        var token = tokenStorage.Get();

        return Ok(token);
    }

    [HttpPost("owner")]
    public async Task<ActionResult<JwtDto>> SignInOwner(OwnerSignInCommand command)
    {
        try
        {
            await ownerSignInHandler.HandleAsync(command);
        }
        catch (UserNotFoundException e)
        {
            return NotFound();
        }
        catch (InvalidCredentialException)
        {
            return Unauthorized();
        }

        var token = tokenStorage.Get();
        return Ok(token);
    }
}