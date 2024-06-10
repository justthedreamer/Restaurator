using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.RestaurantModel;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal class GetRestaurantTablesHandler(RestauratorDbContext dbContext,IMapper mapper)
    : IQueryHandler<GetRestaurantTables, IEnumerable<TableDto>>
{
    public async Task<IEnumerable<TableDto>> HandleAsync(GetRestaurantTables query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Tables)
            .SingleOrDefaultAsync(r => r.RestaurantId == restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var tables = restaurant.Tables.AsEnumerable();
        var dtos = tables.Select(mapper.Map<Table, TableDto>);
        return dtos;
    }
}