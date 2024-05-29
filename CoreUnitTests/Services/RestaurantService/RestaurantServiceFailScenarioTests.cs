using Core.Exceptions.Policies;
using Core.Exceptions.Restaurant;
using Core.Model.AddressModel;
using Core.Model.OrderModel;
using Core.Model.RestaurantModel;
using Core.Policies;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.RestaurantService;

public class RestaurantServiceFailScenarioTests
{
    [Fact]
    public void change_restaurant_address_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var address = new Address("Kraków", "Fosza", "100");

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.ChangeRestaurantAddress(restaurant, address, UserRole.Employee);
        });
    }

    [Fact]
    public void add_public_phone_number_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var phoneNumber = new PhoneNumber("123456789");

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddPublicPhoneNumber(restaurant, phoneNumber, UserRole.Employee);
        });
    }

    [Fact]
    public void add_public_phone_number_when_already_exist_should_throw_phone_number_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var phoneNumber = new PhoneNumber("123456789");
        restaurant.AddPublicPhoneNumber(phoneNumber);
        
        Should.Throw<PhoneNumberAlreadyExistException>(() =>
        {
            _restaurantService.AddPublicPhoneNumber(restaurant, phoneNumber, UserRole.Manager);
        });
    }

    [Fact]
    public void remove_public_phone_number_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var phoneNumber = restaurant.PublicPhoneNumbers.First();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddPublicPhoneNumber(restaurant, phoneNumber, UserRole.Employee);
        });
    }

    [Fact]
    public void remove_public_phone_number_when_not_found_should_throw_phone_number_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var phoneNumber = new PhoneNumber("123456789");

        Should.Throw<PhoneNumberNotFoundException>(() =>
        {
            _restaurantService.RemovePublicPhoneNumber(restaurant, phoneNumber, UserRole.Manager);
        });
    }

    [Fact]
    public void add_public_email_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var email = new Email("emailTest@email.com");
        
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddPublicEmail(restaurant, email, UserRole.Employee);
        });
    }

    [Fact]
    public void add_public_email_when_already_exist_should_throw_email_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var email = restaurant.PublicEmails.First();
        
        Should.Throw<EmailAlreadyExistException>(() =>
        {
            _restaurantService.AddPublicEmail(restaurant, email, UserRole.Manager);
        });
    }

    [Fact]
    public void remove_public_email_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var email = new Email("emailTest@email.com");
        
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.RemovePublicEmail(restaurant, email, UserRole.Employee);
        });
    }

    [Fact]
    public void remove_public_email_when_not_found_should_throw_email_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var email = new Email("emailTest@gmail.com");
        
        Should.Throw<EmailNotFoundException>(() =>
        {
            _restaurantService.RemovePublicEmail(restaurant, email, UserRole.Manager);
        });
    }

    [Fact]
    public void add_table_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 5);

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddTable(restaurant,table, UserRole.Employee);
        });
    }

    [Fact]
    public void add_table_when_already_exist_should_throw_table_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 5);
        restaurant.AddTable(table);

        Should.Throw<TableAlreadyExistException>(() =>
        {
            _restaurantService.AddTable(restaurant,table, UserRole.Manager);
        });
    }

    [Fact]
    public void remove_table_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 5);
        restaurant.AddTable(table);

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.RemoveTable(restaurant,table, UserRole.Employee);
        });
    }

    [Fact]
    public void remove_table_when_not_found_should_throw_table_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 5);

        Should.Throw<TableNotFoundException>(() =>
        {
            _restaurantService.RemoveTable(restaurant,table, UserRole.Manager);
        });
    }

    [Fact]
    public void add_order_when_already_exist_should_throw_order_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var order = OrderFactory.CreateRestaurantOrder();
        restaurant.AddOrder(order);
        
        Should.Throw<OrderAlreadyExistException>(() =>
        {
            _restaurantService.AddOrder(restaurant,order);
        });
    }

    [Fact]
    public void remove_order_when_not_found_should_throw_order_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var order = OrderFactory.CreateRestaurantOrder();
        
        Should.Throw<OrderNotFoundException>(() =>
        {
            _restaurantService.RemoveOrder(restaurant,order);
        });
    }

    [Fact]
    public void add_reservation_when_already_exist_should_throw_reservation_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 2);
        restaurant.AddTable(table);
        var reservation = ReservationFactory.CreateReservation(table);
        restaurant.AddReservation(reservation);
        
        Should.Throw<ReservationAlreadyExistException>(() =>
        {
            _restaurantService.AddReservation(restaurant,reservation);
        });
    }

    [Fact]
    public void remove_reservation_when_not_found_should_throw_reservation_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var table = new Table(Guid.NewGuid(), 2);
        restaurant.AddTable(table);
        var reservation = ReservationFactory.CreateReservation(table);
        
        Should.Throw<ReservationNotFoundException>(() =>
        {
            _restaurantService.RemoveReservation(restaurant,reservation);
        });
    }

    [Fact]
    public void add_service_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var service = ServiceFactory.CreateService();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddService(restaurant,service,UserRole.Employee);
        });
    }

    [Fact]
    public void add_service_when_already_exist_should_throw_service_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var service = ServiceFactory.CreateService();
        restaurant.AddService(service);
        
        Should.Throw<ServiceAlreadyExistException>(() =>
        {
            _restaurantService.AddService(restaurant,service,UserRole.Manager);
        });
    }

    [Fact]
    public void remove_service_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var service = ServiceFactory.CreateService();
        restaurant.AddService(service);
        
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.RemoveService(restaurant,service,UserRole.Employee);
        });
    }

    [Fact]
    public void remove_service_when_not_found_should_throw_service_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var service = ServiceFactory.CreateService();
        
        Should.Throw<ServiceNotFoundException>(() =>
        {
            _restaurantService.RemoveService(restaurant,service,UserRole.Manager);
        });
    }

    [Fact]
    public void add_menu_item_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var menuItem = MenuItemFactory.CreateMenuItem();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddMenuItem(restaurant,menuItem,UserRole.Employee);
        });
    }

    [Fact]
    public void add_menu_item_when_already_exist_should_throw_menu_item_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var menuItem = MenuItemFactory.CreateMenuItem();
        restaurant.Menu.AddMenuItem(menuItem);
        
        Should.Throw<MenuItemAlreadyExistException>(() =>
        {
            _restaurantService.AddMenuItem(restaurant,menuItem,UserRole.Manager);
        });
    }

    [Fact]
    public void remove_menu_item_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var menuItem = MenuItemFactory.CreateMenuItem();
        restaurant.Menu.AddMenuItem(menuItem);

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.RemoveMenuItem(restaurant,menuItem,UserRole.Employee);
        });
    }

    [Fact]
    public void remove_menu_item_when_not_found_should_throw_menu_item_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var menuItem = MenuItemFactory.CreateMenuItem();
        
        Should.Throw<MenuItemNotFoundException>(() =>
        {
            _restaurantService.RemoveMenuItem(restaurant,menuItem,UserRole.Manager);
        });
    }

    [Fact]
    public void add_daily_employee_schedule_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.AddDailyEmployeeSchedule(restaurant,dailyEmployeeSchedule,UserRole.Employee);
        });
    }

    [Fact]
    public void
        add_daily_employee_schedule_when_already_exist_should_throw_daily_employee_schedule_already_exist_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule();
        restaurant.AddDailyEmployeeSchedule(dailyEmployeeSchedule);
        
        Should.Throw<DailyEmployeeScheduleAlreadyExistException>(() =>
        {
            _restaurantService.AddDailyEmployeeSchedule(restaurant,dailyEmployeeSchedule,UserRole.Manager);
        });
    }

    [Fact]
    public void remove_daily_employee_schedule_with_no_permitted_role_should_throw_policy_no_permission_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _restaurantService.RemoveDailyEmployeeSchedule(restaurant,dailyEmployeeSchedule,UserRole.Employee);
        });
    }

    [Fact]
    public void remove_daily_employee_schedule_when_not_found_should_throw_daily_employee_schedule_not_found_exception()
    {
        var rId = Guid.NewGuid();
        var restaurant = RestaurantFactory.CreateRestaurant(rId);
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule();
        
        Should.Throw<DailyEmployeeScheduleNotFoundException>(() =>
        {
            _restaurantService.RemoveDailyEmployeeSchedule(restaurant,dailyEmployeeSchedule,UserRole.Manager);
        });
    }


    private readonly IRestaurantService
        _restaurantService = new Core.Services.RestaurantServiceFailScenario(new RestaurantPolicy());
}