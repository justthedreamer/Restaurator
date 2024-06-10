using Application.Security;
using Core.Model.StaffModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Security;

internal static class Extensions
{
    internal static IServiceCollection AddSecurity(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddSingleton<IPasswordManager, PasswordManager>();
        return services;
    }
}