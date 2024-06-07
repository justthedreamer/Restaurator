using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_App.ApiClient.Abstraction;
using Razor_App.Services;

namespace Razor_App.Pages.Owner;

public class Index(IRestauratorApiClient client, ITokenService tokenService) : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        var user = HttpContext.User.Claims.ToList();
        return RedirectToPage("/UnAuthorize/Index");
    }
}