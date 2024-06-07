namespace Razor_App.Middleware;

public static class Extensions
{
    public static IApplicationBuilder UseAccessTokenMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AccessTokenMiddleware>();
    }
}