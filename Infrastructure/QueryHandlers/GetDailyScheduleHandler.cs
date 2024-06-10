using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Exceptions.Restaurant;
using Core.Model.ScheduleModel;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetDailyScheduleHandler(RestauratorDbContext dbContext, IMapper mapper)
    : IQueryHandler<GetDailySchedule, DailyEmployeeScheduleDto>
{
    public async Task<DailyEmployeeScheduleDto> HandleAsync(GetDailySchedule query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var restaurant = await dbContext.Restaurants
            .AsNoTracking()
            .Include(r => r.Schedules)
            .ThenInclude(s => s.EmployeeSchedules)
            .ThenInclude(e => e.Employee)
            .SingleOrDefaultAsync(r => r.RestaurantId == restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var scheduleId = new DailyEmployeeScheduleId(query.ScheduleId);

        var schedule = restaurant.Schedules.SingleOrDefault(s => s.DailyEmployeeScheduleId == scheduleId);
        if (schedule is null)
        {
            throw new DailyEmployeeScheduleNotFoundException();
        }

        var dto = mapper.Map<(DailyEmployeeSchedule, IEnumerable<EmployeeScheduleDto>), DailyEmployeeScheduleDto>((
            schedule,
            schedule.EmployeeSchedules.Select(mapper.Map<EmployeeSchedule, EmployeeScheduleDto>)));

        return dto;
    }
}