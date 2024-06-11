using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Exceptions.Restaurant;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;

namespace Application.Commands.Handlers;

public class DeleteOrderHandler(IRestaurantRepository restaurantRepository,IRestaurantService restaurantService) : ICommandHandler<DeleteOrder>
{
    public async Task HandleAsync(DeleteOrder command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var restaurant = await restaurantRepository.GetAsync(restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var orderId = new OrderId(command.OrderId);
        var order = restaurant.Orders.SingleOrDefault(o => o.OrderId == orderId);

        if (order is null)
        {
            throw new OrderNotFoundException();
        }
        
        restaurantService.RemoveOrder(restaurant,order);
        
        await restaurantRepository.UpdateAsync(restaurant);
    }
}