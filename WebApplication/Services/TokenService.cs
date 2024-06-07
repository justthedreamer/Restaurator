namespace Razor_App.Services;

internal sealed class TokenService(IHttpContextAccessor httpContextAccessor) : ITokenService
{
    public void SetAccessToken(string token)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Secure = false, //todo for https
            SameSite = SameSiteMode.Strict
        };
        
        httpContextAccessor?.HttpContext?.Response.Cookies.Append("AccessToken", token, cookieOptions);
    }

    public string GetAccessToken()
    {
        string? token = "";
        httpContextAccessor?.HttpContext?.Request.Cookies.TryGetValue("AccessToken", out token);
        return token ?? "";
    }
}