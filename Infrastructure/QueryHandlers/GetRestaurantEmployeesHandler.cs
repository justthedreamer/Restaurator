using Application.DTO.User;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.StaffModel;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal class GetRestaurantEmployeesHandler(RestauratorDbContext dbContext, IMapper mapper)
    : IQueryHandler<GetRestaurantEmployees, IEnumerable<EmployeeDto>>
{
    public async Task<IEnumerable<EmployeeDto>> HandleAsync(GetRestaurantEmployees query)
    {
        var restaurant = await dbContext.Restaurants.AsNoTracking()
            .Include(restaurant => restaurant.Employees)
            .SingleOrDefaultAsync(r => r.RestaurantId.Value == query.RestaurantId);


        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var employees = restaurant.Employees;
        var profiles = employees.Select(e => mapper.Map<Employee, EmployeeDto>(e));
        return profiles;
    }
}