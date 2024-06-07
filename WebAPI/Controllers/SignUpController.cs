using Application.Commands;
using Application.Commands.Abstraction;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[ApiController]
[Route("/sign-up")]
public class SignUpController
    (ICommandHandler<SignUpCommand> signUpHandler)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> SignUp(SignUpCommand command)
    {
        var userId = Guid.NewGuid();
        command = command with { UserId = userId };

        try
        {        
            await signUpHandler.HandleAsync(command);
        }
        catch (AccountAlreadyExist e)
        {
            return BadRequest(e.Message);
        }

        return Created();
    }
}