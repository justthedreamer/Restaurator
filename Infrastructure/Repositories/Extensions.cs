using Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories;

internal static class Extensions
{
    internal static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository,EmployeeRepository>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        
        return services;
    }
}