using Application.Commands.Abstraction;
using Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Commands.Extensions;

public static class Extensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ICommandHandler<>).Assembly;

        services
            .Scan(s => s.FromAssemblies(applicationAssembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}