using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.MenuModel;
using Core.Model.ServicesModel;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantMenuHandler(RestauratorDbContext dbContext, IMapper mapper)
    : IQueryHandler<GetRestaurantMenu, MenuDto>
{
    public async Task<MenuDto> HandleAsync(GetRestaurantMenu query)
    {
        var restaurant = await dbContext.Restaurants
            .AsNoTracking()
            .Include(r => r.Menu)
            .ThenInclude(m => m.MenuItems)
            .ThenInclude(x => x.Ingredients)
            .Include(r => r.Services)
            .SingleOrDefaultAsync(r => r.RestaurantId.Value == query.RestaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var services = restaurant.Services.Select(mapper.Map<Service, ServiceDto>);
        var menuItems = restaurant.Menu.MenuItems.Select(mapper.Map<MenuItem, MenuItemDto>);

        return new MenuDto { MenuItems = menuItems, Services = services };
    }
}