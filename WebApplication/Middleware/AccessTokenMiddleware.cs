using Razor_App.Services;

namespace Razor_App.Middleware;

public class AccessTokenMiddleware(RequestDelegate next,ITokenService tokenService)
{
    public async Task Invoke(HttpContext context)
    {
        var accessToken = tokenService.GetAccessToken();
        if (!string.IsNullOrEmpty(accessToken))
        {
            context.Request.Headers.Append("Authorization",$"Bearer {accessToken}");
        }

        await next(context);
    }
}