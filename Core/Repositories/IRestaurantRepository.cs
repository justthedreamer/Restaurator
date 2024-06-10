using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.ValueObject.Restaurant;

namespace Core.Repositories;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetAsync(RestaurantId restaurantId);
    Task CreateAsync(Restaurant restaurant);
    Task UpdateAsync(Restaurant restaurant);
    Task DeleteAsync(Restaurant restaurant);
}