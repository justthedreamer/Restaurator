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

internal class GetRestaurantProfileHandler(RestauratorDbContext dbContext,IMapper mapper)
    : IQueryHandler<GetRestaurantProfile, RestaurantProfileDto>
{

    public async Task<RestaurantProfileDto> HandleAsync(GetRestaurantProfile query)
    {

        var restaurantId = new RestaurantId(query.restaurantId);

        
        var restaurant = await dbContext.Restaurants
            .AsNoTracking()
            .SingleOrDefaultAsync(r => r.RestaurantId == restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }
        
        var profile = mapper.Map<Restaurant, RestaurantProfileDto>(restaurant);
        return profile;
    }
}