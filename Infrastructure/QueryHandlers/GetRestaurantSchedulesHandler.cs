using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.ScheduleModel;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantSchedulesHandler(RestauratorDbContext dbContext, IMapper mapper)
    : IQueryHandler<GetRestaurantSchedules, IEnumerable<DailyEmployeeScheduleDto>>
{
    public async Task<IEnumerable<DailyEmployeeScheduleDto>> HandleAsync(GetRestaurantSchedules query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var restaurant = await dbContext.Restaurants
            .AsNoTracking()
            .Include(x => x.Schedules)
            .ThenInclude(s => s.EmployeeSchedules)
            .ThenInclude(es => es.Employee)
            .SingleOrDefaultAsync(x => x.RestaurantId == restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var dtos = restaurant.Schedules.Select(s =>
            mapper.Map<(DailyEmployeeSchedule, IEnumerable<EmployeeScheduleDto>),DailyEmployeeScheduleDto>(
                (s, ConvertToDto(s.EmployeeSchedules))));

        return dtos;
    }

    private IEnumerable<EmployeeScheduleDto> ConvertToDto(IEnumerable<EmployeeSchedule> employeeSchedules)
    {
        return employeeSchedules.Select(mapper.Map<EmployeeSchedule, EmployeeScheduleDto>);
    }
}