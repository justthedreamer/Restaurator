using System.Runtime.InteropServices;
using Core.Model.AddressModel;
using Core.Model.RestaurantModel;
using Core.Policies;
using Core.Services;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.RestaurantService;

public class RestaurantServiceSuccessScenarioTests
{
    [Theory]
    [InlineData(UserRole.Owner)]
    public void change_restaurant_address_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var address = new Address("Warsaw", "Downtown", "30");

        //Act
        _restaurantService.ChangeRestaurantAddress(restaurant, address, userRole);

        //Assert
        restaurant.Address.ShouldBe(address);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void add_public_phone_number_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var phoneNumber = new PhoneNumber("999999999");

        //Act
        _restaurantService.AddPublicPhoneNumber(restaurant, phoneNumber, userRole);

        //Assert
        restaurant.PublicPhoneNumbers.ShouldContain(phoneNumber);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void remove_public_phone_number_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var phoneNumber = new PhoneNumber("999999999");
        restaurant.AddPublicPhoneNumber(phoneNumber);

        //Act
        _restaurantService.RemovePublicPhoneNumber(restaurant, phoneNumber, userRole);

        //Assert
        restaurant.PublicPhoneNumbers.ShouldNotContain(phoneNumber);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void add_public_email_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var email = new Email("email@test.com");

        //Act
        _restaurantService.AddPublicEmail(restaurant, email, userRole);

        //Assert
        restaurant.PublicEmails.ShouldContain(email);
    }

    [Theory]
    [InlineData(UserRole.Owner)]
    [InlineData(UserRole.Manager)]
    public void remove_email_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var email = new Email("email@test.com");
        restaurant.AddPublicEmail(email);

        //Act
        _restaurantService.RemovePublicEmail(restaurant, email, userRole);

        //Assert
        restaurant.PublicEmails.ShouldNotContain(email);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void add_table_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var table = new Table(Guid.NewGuid(), 4);

        //Act
        _restaurantService.AddTable(restaurant, table, userRole);

        //Assert
        restaurant.Tables.ShouldContain(table);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void remove_table_with_permitted_roles(UserRole userRole)
    {
        //Assert
        var restaurant = RestaurantFactory.CreateRestaurant(Guid.NewGuid());
        var table = new Table(Guid.NewGuid(), 4);
        restaurant.AddTable(table);
        
        //Act
        _restaurantService.RemoveTable(restaurant, table, userRole);

        //Assert
        restaurant.Tables.ShouldNotContain(table);
    }

    [Fact]
    public void add_order_restaurant_order_list_should_contains_order()
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var order = OrderFactory.CreateRestaurantOrder();
        
        //Act
        _restaurantService.AddOrder(restaurant,order);
        
        //Assert
        restaurant.Orders.ShouldContain(order);
    }
    
    [Fact]
    public void remove_order_restaurant_order_list_should_not_contains_order()
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var order = OrderFactory.CreateRestaurantOrder();
        restaurant.AddOrder(order);
        
        //Act
        _restaurantService.RemoveOrder(restaurant,order);
        
        //Assert
        restaurant.Orders.ShouldNotContain(order);
    }

    [Fact]
    public void add_reservation_restaurant_reservations_list_should_contains_reservation()
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var table = new Table(Guid.NewGuid(), 2);
        var reservation = ReservationFactory.CreateReservation(table);
        
        //Act
        _restaurantService.AddReservation(restaurant,reservation);
        
        //Assert
        restaurant.Reservations.ShouldContain(reservation);
    }
    
    [Fact]
    public void remove_reservation_restaurant_reservations_list_should_not_contains_reservation()
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var table = new Table(Guid.NewGuid(), 2);
        var reservation = ReservationFactory.CreateReservation(table);
        restaurant.AddReservation(reservation);
        
        //Act
        _restaurantService.RemoveReservation(restaurant,reservation);
        
        //Assert
        restaurant.Reservations.ShouldNotContain(reservation);
    }

    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void add_service_restaurant_service_list_should_contains_service(UserRole userRole)
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var service = ServiceFactory.CreateService();
        
        //Act
        _restaurantService.AddService(restaurant,service,userRole);
        
        //Assert
        restaurant.Services.ShouldContain(service);
    }
    
    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void remove_service_restaurant_service_list_should_contains_service(UserRole userRole)
    {
        //Arrange
        var restaurant = RestaurantFactory.CreateRestaurant();
        var service = ServiceFactory.CreateService();
        restaurant.AddService(service);
        
        //Act
        _restaurantService.RemoveService(restaurant,service,userRole);
        
        //Assert
        restaurant.Services.ShouldNotContain(service);
    }
    
    private readonly IRestaurantService _restaurantService = new RestaurantServiceFailScenario(new RestaurantPolicy());
}