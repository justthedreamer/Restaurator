using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTO;
using Application.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

internal class Authenticator(IOptions<AuthOptions> options) : IAuthenticator
{
    public JwtDto CreateToken(Guid userId, string role)
    {
        var issuer = options.Value.Issuer;
        var audience = options.Value.Audience;
        var expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey));
        var algorithm = SecurityAlgorithms.HmacSha256;
        var signingCredentials = new SigningCredentials(securityKey, algorithm);
        
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        
        var now = DateTime.Now;
        var expires = now.Add(expiry);
        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new Claim(ClaimTypes.Role, role),
        };

        var jwt = new JwtSecurityToken(issuer, audience, claims, now, expires, signingCredentials);
        var accessToken = jwtSecurityTokenHandler.WriteToken(jwt);

        return new JwtDto() { AccessToken = accessToken };
    }
}