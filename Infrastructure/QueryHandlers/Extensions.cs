using Application.DTO;
using Application.DTO.User;
using Application.Queries;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.QueryHandlers;

public static class Extensions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        var infrastructureAssembly = typeof(AppOptions).Assembly;

        services
            .Scan(s => s.FromAssemblies(infrastructureAssembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}