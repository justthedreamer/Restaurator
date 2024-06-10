using System.ComponentModel.Design;
using Application.Commands.Extensions;
using Microsoft.Extensions.DependencyInjection;


namespace Application.Extensions;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommandHandlers();
        return services;
    }
}