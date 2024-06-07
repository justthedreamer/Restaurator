using System.ComponentModel.Design;
using Core.Policies;
using Core.Services;
using Core.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddPolicies();
        services.AddServices();
        return services;
    }
}