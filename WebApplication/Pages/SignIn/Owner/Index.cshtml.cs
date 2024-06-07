using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_App.ApiClient.Abstraction;
using Razor_App.ApiClient.Actions;
using Razor_App.ApiClient.Utilities;
using Razor_App.Services;

namespace Razor_App.Pages.SignIn.Owner;

/// <summary>
/// Represent owner model for sig in.
/// </summary>
public class OwnerSignInModel(IRestauratorApiClient restauratorApiClient,ITokenService tokenService) : PageModel
{
    [BindProperty] public string Login { get; set; }
    [BindProperty] public string Password { get; set; }

    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var obj = new
        {
            Login = Login,
            Password = Password
        };

        var content = SerializeHelper.CreateJsonStringContent(obj);

        var response = await restauratorApiClient.HandlePostAsync(RestauratorActions.OwnerSignIn, content, null);

        if (response.IsSuccessStatusCode)
        {
            var accessToken = await restauratorApiClient.GetAccessTokenFromResponseAsync(response);
            tokenService.SetAccessToken(accessToken!);
            return RedirectToPage("/Owner");
        }
        else
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ErrorMessage = "Invalid credentials.";
            }
            else
            {
                ErrorMessage = "Something went wrong. Contact with administrator.";
            }
            return Page();
        }
    }
}