using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Repositories;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class RestaurantRepository(RestauratorDbContext dbContext) : IRestaurantRepository
{
    public async Task<Restaurant?> GetAsync(RestaurantId restaurantId)
    {
        var restaurant = await dbContext.Restaurants
            .Include(r => r.Owner)
            .Include(r => r.Employees)
            .Include(r => r.Reservations).ThenInclude(rs => rs.Table)
            .Include(r => r.Orders).ThenInclude(o => o.MenuItems).ThenInclude(mi => mi.Ingredients)
            .Include(r => r.Orders).ThenInclude(o => o.Services)
            .Include(r => r.Orders).ThenInclude(o => o.PromoCode)
            .Include(r => r.Orders).ThenInclude(o => o.Receipt)
            .Include(r => r.Tables)
            .Include(r => r.Menu).ThenInclude(m => m.MenuItems)
            .Include(r => r.Services)
            .SingleOrDefaultAsync(r => r.RestaurantId == restaurantId);
        return restaurant;
    }

    public Task CreateAsync(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Restaurant restaurant)
    {
        dbContext.Restaurants.Update(restaurant);
        await dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }
}