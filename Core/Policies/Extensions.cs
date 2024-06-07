using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Policies;

internal static class Extensions
{
    internal static IServiceCollection AddPolicies(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeePolicy, EmployeePolicy>();
        services.AddSingleton<IMenuItemPolicy, MenuItemPolicy>();
        services.AddSingleton<IOrderStatePolicy, OrderStatePolicy>();
        services.AddSingleton<IPromoCodePolicy, PromoCodePolicy>();
        services.AddSingleton<IRestaurantPolicy, RestaurantPolicy>();
        services.AddSingleton<ISchedulePolicy, SchedulePolicy>();
        services.AddSingleton<IServicePolicy, ServicePolicy>();
        return services;
    }
}