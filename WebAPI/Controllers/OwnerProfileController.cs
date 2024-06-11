using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[ApiController]
[Route("/owner")]
[Authorize(Policy = "is-owner")]
public class OwnerProfileController
    (IQueryHandler<GetOwnerProfileQuery,OwnerProfileDto> profileHandler)
    : ControllerBase
{
    [HttpGet]
    [Authorize("is-owner")]
    public async Task<ActionResult<OwnerProfileDto>> Get()
    {
        var userId = HttpContext.User.Identity?.Name;
        
        if (userId is null)
            return NotFound();

        var profile = await profileHandler.HandleAsync(new GetOwnerProfileQuery(Guid.Parse(userId)));

        return Ok(profile);
    }
}