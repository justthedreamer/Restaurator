using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_App.ApiClient.Abstraction;
using Razor_App.ApiClient.Actions;
using Razor_App.Model;
using Razor_App.Services;

namespace Razor_App.Pages.Owner;

public class Index(IRestauratorApiClient client, ITokenService tokenService) : PageModel
{
    public OwnerProfile Profile { get; set; }

    public async Task<IActionResult> OnGet()
    {
        var token = tokenService.GetAccessToken();

        if (token is null)
        {
            return RedirectToPage("/UnAuthorized/Index");
        }

        var response = await client.HandleGetAsync(RestauratorActions.GetOwnerProfile, token);

        if (!response.IsSuccessStatusCode)
        {
            return RedirectToPage("/Index");
        }

        var stream = await response.Content.ReadAsStringAsync();
        var profile = JsonSerializer.Deserialize<OwnerProfile>(stream);
        
        if (profile != null)
        {
            Profile = profile;
        }
        
        return Page();
    }
}