using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Exceptions.Restaurant;
using Core.Model.ScheduleModel;
using Core.Model.StaffModel;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

public class CreateEmployeeScheduleHandler(IRestaurantRepository restaurantRepository, IScheduleService scheduleService)
    : ICommandHandler<CreateEmployeeSchedule>
{
    public async Task HandleAsync(CreateEmployeeSchedule command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var restaurant = await restaurantRepository.GetAsync(restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var dailyScheduleId = new DailyEmployeeScheduleId(command.DailyEmployeeScheduleId);
        var dailySchedule = restaurant.Schedules.SingleOrDefault(s => s.DailyEmployeeScheduleId == dailyScheduleId);

        if (dailySchedule is null)
        {
            throw new DailyEmployeeScheduleNotFoundException();
        }


        var employeeId = new UserId(command.EmployeeId);
        var employee = restaurant.Employees.SingleOrDefault(e => e.UserId == employeeId);
        
        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        var employeeScheduleId = new EmployeeScheduleId(command.ScheduleId);
        var employeeSchedule = EmployeeSchedule.CreateEmployeeSchedule(employeeScheduleId, employee, command.From,
            command.To, ScheduleState.WaitingForApproval);

        var requestingUserId = new UserId(command.RequestingUserId);
        var user = restaurant.Owner.UserId == requestingUserId
            ? (User)restaurant.Owner
            : restaurant.Employees.SingleOrDefault(e => e.UserId == requestingUserId);

        if (user is null)
        {
            throw new UserNotFoundException();
        }
        
        scheduleService.AddSchedule(dailySchedule,employeeSchedule,user.UserRole);        
    }
}