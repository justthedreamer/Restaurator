using Core.Exceptions.Policies;
using Core.Exceptions.Restaurant;
using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.User;


namespace Core.Services;

/// <summary>
/// Restaurant service implementation
/// </summary>
internal class RestaurantServiceFailScenario(IRestaurantPolicy restaurantPolicy) : IRestaurantService
{
    
    /// <summary>
    /// Change restaurant address
    /// </summary>
    /// <param name="restaurant">Instance of <see cref="Restaurant"/></param>
    /// <param name="address">New address</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    public void ChangeRestaurantAddress(Restaurant restaurant, Address address, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageRestaurantInformation(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        restaurant.ChangeRestaurantAddress(address);
    }
    
    /// <summary>
    /// Add public phone number
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="phoneNumber">New <see cref="PhoneNumber"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="PhoneNumberAlreadyExistException">If phone number already exist.</exception>
    public void AddPublicPhoneNumber(Restaurant restaurant, PhoneNumber phoneNumber, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToMagePublicInfo(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var phoneNumberExist = restaurant.PublicPhoneNumbers.Any(x => x == phoneNumber);

        if (phoneNumberExist)
            throw new PhoneNumberAlreadyExistException();

        restaurant.AddPublicPhoneNumber(phoneNumber);
    }

    /// <summary>
    /// Remove public phone number
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/> to remove</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="PhoneNumberNotFoundException">If phone number is not found.</exception>
    public void RemovePublicPhoneNumber(Restaurant restaurant, PhoneNumber phoneNumber, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToMagePublicInfo(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var phoneNumberExist = restaurant.PublicPhoneNumbers.Any(x => x == phoneNumber);
        if (!phoneNumberExist)
            throw new PhoneNumberNotFoundException();

        restaurant.RemovePublicPhoneNumber(phoneNumber);
    }

    /// <summary>
    /// Add public email
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="email">New <see cref="Email"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="EmailAlreadyExistException">If email already exist.</exception>
    public void AddPublicEmail(Restaurant restaurant, Email email, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToMagePublicInfo(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var emailExist = restaurant.PublicEmails.Any(x => x == email);
        if (emailExist)
            throw new EmailAlreadyExistException();

        restaurant.AddPublicEmail(email);
    }

    /// <summary>
    /// Remove public email
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="email"><see cref="Email"/> to remove.</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="EmailNotFoundException">If email is not found.</exception>
    public void RemovePublicEmail(Restaurant restaurant, Email email, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToMagePublicInfo(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var emailExist = restaurant.PublicEmails.Any(x => x == email);
        if (!emailExist)
            throw new EmailNotFoundException();

        restaurant.RemovePublicEmail(email);
    }

    /// <summary>
    /// Add new table
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="table">New <see cref="Table"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="TableAlreadyExistException">If table already exist.</exception>
    public void AddTable(Restaurant restaurant, Table table, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageTables(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var tableExist = restaurant.Tables.Any(x => x == table);
        if (tableExist)
            throw new TableAlreadyExistException();

        restaurant.AddTable(table);
    }

    /// <summary>
    /// Remove table
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="table"><see cref="Table"/> to remove</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="TableNotFoundException">If table is not found.</exception>
    public void RemoveTable(Restaurant restaurant, Table table, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageTables(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var tableExist = restaurant.Tables.Any(x => x == table);
        if (!tableExist)
            throw new TableNotFoundException();

        restaurant.RemoveTable(table);
    }

    /// <summary>
    /// Add order
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="order">New <see cref="Order"/></param>
    /// <exception cref="OrderAlreadyExistException">If order already exit.</exception>
    public void AddOrder(Restaurant restaurant, Order order)
    {
        var orderExist = restaurant.Orders.Any(x => x == order);
        if (orderExist)
            throw new OrderAlreadyExistException();

        restaurant.AddOrder(order);
    }

    /// <summary>
    /// Remove order
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="order"><see cref="Order"/> to remove</param>
    /// <exception cref="OrderNotFoundException">If order is not found.</exception>
    public void RemoveOrder(Restaurant restaurant, Order order)
    {
        var orderExist = restaurant.Orders.Any(x => x == order);
        if (!orderExist)
            throw new OrderNotFoundException();

        restaurant.RemoveOrder(order);
    }

    /// <summary>
    /// Add reservation
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="reservation">new <see cref="Reservation"/></param>
    /// <exception cref="ReservationAlreadyExistException">If reservation already exist.</exception>
    public void AddReservation(Restaurant restaurant, Reservation reservation)
    {
        var reservationExist = restaurant.Reservations.Any(x => x == reservation);
        if (reservationExist)
            throw new ReservationAlreadyExistException();

        restaurant.AddReservation(reservation);
    }

    /// <summary>
    /// Remove reservation
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="reservation"><see cref="Reservation"/> to remove</param>
    /// <exception cref="ReservationNotFoundException">If reservation is not found.</exception>
    public void RemoveReservation(Restaurant restaurant, Reservation reservation)
    {
        var reservationExist = restaurant.Reservations.Any(x => x == reservation);
        if (!reservationExist)
            throw new ReservationNotFoundException();

        restaurant.RemoveReservation(reservation);
    }

    /// <summary>
    /// Add service
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="service">New <see cref="Service"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="ServiceAlreadyExistException">Is service already exist.</exception>
    public void AddService(Restaurant restaurant, Service service, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageServices(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var serviceExist = restaurant.Services.Any(x => x == service);
        if (serviceExist)
            throw new ServiceAlreadyExistException();

        restaurant.AddService(service);
    }

    /// <summary>
    /// Remove service
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="service"><see cref="Service"/> to remove</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="ServiceNotFoundException">If service is not found.</exception>
    public void RemoveService(Restaurant restaurant, Service service, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageServices(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var serviceExist = restaurant.Services.Any(x => x == service);
        if (!serviceExist)
            throw new ServiceNotFoundException();

        restaurant.RemoveService(service);
    }

    /// <summary>
    /// Add menu item
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="menuItem">New <see cref="MenuItem"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="MenuItemAlreadyExistException"></exception>
    public void AddMenuItem(Restaurant restaurant, MenuItem menuItem, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageMenuItems(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var menuItemExist = restaurant.Menu.MenuItems.Any(x => x == menuItem);
        if (menuItemExist)
            throw new MenuItemAlreadyExistException();

        restaurant.Menu.AddMenuItem(menuItem);
    }

    /// <summary>
    /// Remove menu item
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="menuItem"><see cref="MenuItem"/> to remove.</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="MenuItemNotFoundException"></exception>
    public void RemoveMenuItem(Restaurant restaurant, MenuItem menuItem, UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageMenuItems(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var menuItemExist = restaurant.Menu.MenuItems.Any(x => x == menuItem);
        if (!menuItemExist)
            throw new MenuItemNotFoundException();

        restaurant.Menu.AddMenuItem(menuItem);
    }

    /// <summary>
    /// Add daily employee schedule
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="dailyEmployeeSchedule">New <see cref="DailyEmployeeSchedule"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="DailyEmployeeScheduleAlreadyExistException">If daily employee schedule already exist</exception>
    public void AddDailyEmployeeSchedule(Restaurant restaurant, DailyEmployeeSchedule dailyEmployeeSchedule,
        UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageDailySchedules(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var scheduleExist = restaurant.Schedules.Any(x => x == dailyEmployeeSchedule);
        if (scheduleExist)
            throw new DailyEmployeeScheduleAlreadyExistException();

        restaurant.AddDailyEmployeeSchedule(dailyEmployeeSchedule);
    }

    /// <summary>
    /// Remove daily employee schedule
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="dailyEmployeeSchedule"><see cref="DailyEmployeeSchedule"/> to remove</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">Is requesting user is not permitted.</exception>
    /// <exception cref="DailyEmployeeScheduleNotFoundException">If daily employee schedule is not found.</exception>
    public void RemoveDailyEmployeeSchedule(Restaurant restaurant, DailyEmployeeSchedule dailyEmployeeSchedule,
        UserRole userRole)
    {
        var isPermitted = restaurantPolicy.IsPermittedToManageDailySchedules(userRole);
        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var scheduleExist = restaurant.Schedules.Any(x => x == dailyEmployeeSchedule);
        
        if (!scheduleExist)
            throw new DailyEmployeeScheduleNotFoundException();

        restaurant.RemoveDailyEmployeeSchedule(dailyEmployeeSchedule);
    }

   
}