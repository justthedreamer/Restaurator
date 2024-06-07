using System.Text;
using Application.Abstraction;
using Application.Security;
using Core.ValueObject.Staff.User;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

internal static class Extensions
{
    private const string SectionName = "auth";

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthOptions>(configuration.GetRequiredSection(SectionName));
        var options = configuration.GetOptions<AuthOptions>(SectionName);

        services
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<ITokenStorage, HttpContextTokenStorage>()
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Audience = options.Audience;
                x.IncludeErrorDetails = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)),
                };
                x.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        //todo replace by system logger
                        Console.WriteLine(context.Exception);
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization(authorization =>
        {
            authorization.AddPolicy("is-owner", policy => { policy.RequireRole(UserRole.Owner); });
            authorization.AddPolicy("is-manager", policy => { policy.RequireRole(UserRole.Manager); });
            authorization.AddPolicy("is-owner-or-manager", policy => { policy.RequireRole(UserRole.Owner,UserRole.Manager); });
        });

        return services;
    }
}