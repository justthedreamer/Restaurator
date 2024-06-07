using Application.DTO;
using Application.DTO.User;
using Application.Queries;
using Application.Queries.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.QueryHandlers;

public static class Extensions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.AddScoped<IQueryHandler<GetEmployeeProfile, EmployeeDto>,GetEmployeeProfileHandler>();
        services.AddScoped<IQueryHandler<GetOwnerProfileQuery, OwnerProfileDto>,GetOwnerProfileHandler>();
        services.AddScoped<IQueryHandler<GetRestaurantEmployees, IEnumerable<EmployeeDto>>,GetRestaurantEmployeesHandler>();
        services.AddScoped<IQueryHandler<GetRestaurantMenu,MenuDto >,GetRestaurantMenuHandler>();
        services.AddScoped<IQueryHandler<GetRestaurantOrders, IEnumerable<OrderDto>>,GetRestaurantOrdersHandler>();
        services.AddScoped<IQueryHandler<GetRestaurantProfile, RestaurantProfileDto>,GetRestaurantProfileHandler>();
        services.AddScoped<IQueryHandler<GetRestaurantReservations, IEnumerable<ReservationDto>>,GetRestaurantReservationsHandler>();
        return services;
    }
}