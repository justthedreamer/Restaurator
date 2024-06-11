using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Model.AddressModel;
using Core.Model.OrderModel;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Address;
using Core.ValueObject.Common;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Staff.Employee;

namespace Application.Commands.Handlers;

internal sealed class CreateDeliveryOrderHandler(
    IRestaurantRepository restaurantRepository,
    IRestaurantService restaurantService) : ICommandHandler<CreateDeliveryOrder>
{
    public async Task HandleAsync(CreateDeliveryOrder command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var restaurant = await restaurantRepository.GetAsync(restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var orderId = new OrderId(command.OrderId);
        var date = new OrderCreateDate(DateTime.Now);
        var state = OrderState.InProgress;
        var customerFirstName = new FirstName(command.CustomerFirstName);
        var customerLastName = new LastName(command.CustomerLastName);
        var city = new City(command.CustomerCity);
        var street = new Street(command.CustomerStreet);
        var houseNumber = new HouseNumber(command.CustomerHouseNumber);
        var address = new Address(city, street, houseNumber);
        var phoneNumber = new PhoneNumber(command.CustomerPhoneNumber);
        var order = new DeliveryOrder(orderId, state, date, customerFirstName, customerLastName, address, phoneNumber,
            null);


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

        restaurantService.AddOrder(restaurant, order);
        await restaurantRepository.UpdateAsync(restaurant);
    }
}