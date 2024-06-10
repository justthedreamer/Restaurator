using Application.Commands.Abstraction;
using Application.Commands.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Commands.Extensions;

public static class Extensions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<EmployeeSignInCommand>, EmployeeSignInHandler>();
        services.AddScoped<ICommandHandler<OwnerSignInCommand>, OwnerSignInHandler>();
        services.AddScoped<ICommandHandler<SignUpCommand>, SignUpHandler>();
        services.AddScoped<ICommandHandler<CreateDailySchedule>, CreateDailyScheduleHandler>();
        services.AddScoped<ICommandHandler<CreateEmployeeSchedule>, CreateEmployeeScheduleHandler>();
        services.AddScoped<ICommandHandler<CreateRestaurantOrder>, CreateRestaurantOrderHandler>();
        
        return services;
    }
}