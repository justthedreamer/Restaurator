using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Exceptions.Restaurant;
using Core.Model.OrderModel;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;

namespace Application.Commands.Handlers;

public class CreateRestaurantOrderHandler(IRestaurantRepository restaurantRepository,IRestaurantService  restaurantService)
    : ICommandHandler<CreateRestaurantOrder>
{
    public async Task HandleAsync(CreateRestaurantOrder command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var restaurant = await restaurantRepository.GetAsync(restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var tableId = new TableId(command.TableId);
        var table = restaurant.Tables.SingleOrDefault(t => t.TableId == tableId);

        if (table is null)
        {
            throw new TableNotFoundException();
        }

        var orderId = new OrderId(command.OrderId);
        var date = new OrderCreateDate(DateTime.Now);
        var state = OrderState.InProgress;
        var order = new RestaurantOrder(orderId, state, date, table);

        if (command.MenuItems is not null)
        {
            var menuItemsIds = command.MenuItems;
            var menuItems = restaurant.Menu.MenuItems.Where(x => menuItemsIds.Contains(x.MenuItemId));

            foreach (var menuItem in menuItems)
            {
                order.AddMenuItem(menuItem);
            }
        }

        if (command.Services is not null)
        {
            var servicesIds = command.Services;
            var services = restaurant.Services.Where(x => servicesIds.Contains(x.ServiceId));

            foreach (var service in services)
            {
                order.AddService(service);
            }
        }
        
        restaurantService.AddOrder(restaurant,order);
        await restaurantRepository.UpdateAsync(restaurant);
    }
}