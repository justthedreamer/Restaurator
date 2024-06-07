using Application.Abstraction;
using Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Auth;

internal sealed class HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor) : ITokenStorage
{
    private const string TokenKey = "jwt";
    
    public void Set(JwtDto jwtDto)
    {
        httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwtDto);
    }

    
    public JwtDto Get()
    {
        if (httpContextAccessor.HttpContext is null)
        {
            return null!;
        }

        if (httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
        {
            return (jwt as JwtDto)!;
        }

        return null!;
    }
}