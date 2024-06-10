using Application.Security;
using Core.Model.StaffModel;
using Core.Services.Abstraction;
using Core.ValueObject.Staff.User;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.DAL.Database;

/// <summary>
/// Represent database initializer
/// </summary>
/// <param name="serviceProvider">Service provider <see cref="IServiceProvider"/></param>
internal sealed class DatabaseInitializer(IServiceProvider serviceProvider,IPasswordManager passwordManager,IRestaurantService restaurantService,IScheduleService scheduleService) : IHostedService
{

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<RestauratorDbContext>();
        await dbContext.Database.EnsureDeletedAsync(cancellationToken);
        await dbContext.Database.MigrateAsync(cancellationToken);
        
        var dbFactory = new DatabaseInitFactory(passwordManager,restaurantService);

        var owner = dbFactory.CreateOwner();
        var restaurant = dbFactory.CreateRestaurant(owner);
        var employees = dbFactory.CreateEmployees();
        
        foreach (var employee in employees)
        {
            restaurant.AddEmployee(employee);
        }

        var schedule = dbFactory.CreateSchedule();

        restaurantService.AddDailyEmployeeSchedule(restaurant,schedule,UserRole.Owner);

        var employeeSchedules = dbFactory.CreateDailyEmployeeSchedule(employees);

        foreach (var employeeSchedule in employeeSchedules)
        {
            scheduleService.AddSchedule(schedule,employeeSchedule,UserRole.Owner);
        }
        
        await dbContext.AddAsync(owner, cancellationToken);
        await dbContext.AddAsync(restaurant);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}