using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Model.ScheduleModel;
using Core.Model.StaffModel;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

public class CreateDailyScheduleHandler(IRestaurantRepository restaurantRepository,IRestaurantService restaurantService) : ICommandHandler<CreateDailySchedule>
{
    public async Task HandleAsync(CreateDailySchedule command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var restaurant = await restaurantRepository.GetAsync(restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var userId = new UserId(command.UserId);

        var user = restaurant.Owner.UserId == userId
            ? (User)restaurant.Owner
            : restaurant.Employees.SingleOrDefault(e => e.UserId == userId);

        if (user is null)
        {
            throw new UserNotFoundException();
        }

        var scheduleId = new DailyEmployeeScheduleId(command.ScheduleId);
        var scheduleDate = new DailyScheduleDate(command.Date);
        
        var schedule = new DailyEmployeeSchedule(scheduleId, scheduleDate);

        restaurantService.AddDailyEmployeeSchedule(restaurant,schedule,user.UserRole);
        await restaurantRepository.UpdateAsync(restaurant);
    }
}