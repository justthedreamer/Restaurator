using Core.Model.RestaurantModel;
using Core.Services.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Services;

internal static class Extensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IEmployeeService, EmployeeService>();
        services.AddSingleton<IMenuItemService, MenuItemService>();
        services.AddSingleton<IOrderService, OrderService>();
        services.AddSingleton<IPromoCodeService, PromoCodeService>();
        services.AddSingleton<IReservationService, ReservationService>();
        services.AddSingleton<IRestaurantService, RestaurantService>();
        services.AddSingleton<IScheduleService, ScheduleService>();
        services.AddSingleton<IServicesService, ServicesService>();

        return services;
    }
}