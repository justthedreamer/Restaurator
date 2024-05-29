using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

/// <summary>
/// Restaurant service interface
/// </summary>
public interface IRestaurantService
{
    /// <summary>
    /// Change restaurant address
    /// </summary>
    /// <param name="restaurant">Instance of <see cref="Restaurant"/></param>
    /// <param name="address">New address</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void ChangeRestaurantAddress(Restaurant restaurant, Address address, UserRole userRole);

    /// <summary>
    /// Add public phone number
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="phoneNumber">New <see cref="PhoneNumber"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void AddPublicPhoneNumber(Restaurant restaurant, PhoneNumber phoneNumber, UserRole userRole);

    /// <summary>
    /// Remove public phone number
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="phoneNumber"><see cref="PhoneNumber"/> to remove</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void RemovePublicPhoneNumber(Restaurant restaurant, PhoneNumber phoneNumber, UserRole userRole);

    /// <summary>
    /// Add public email
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="email">New <see cref="Email"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void AddPublicEmail(Restaurant restaurant, Email email, UserRole userRole);

    /// <summary>
    /// Remove public email
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="email"><see cref="Email"/> to remove.</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void RemovePublicEmail(Restaurant restaurant, Email email, UserRole userRole);

    /// <summary>
    /// Add new table
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="table">New <see cref="Table"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void AddTable(Restaurant restaurant, Table table, UserRole userRole);

    /// <summary>
    /// Remove table
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="table"><see cref="Table"/> to remove</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void RemoveTable(Restaurant restaurant, Table table, UserRole userRole);

    /// <summary>
    /// Add order
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="order">New <see cref="Order"/></param>
    void AddOrder(Restaurant restaurant, Order order);

    /// <summary>
    /// Remove order
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="order"><see cref="Order"/> to remove</param>
    void RemoveOrder(Restaurant restaurant, Order order);

    /// <summary>
    /// Add reservation
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="reservation">new <see cref="Reservation"/></param>
    void AddReservation(Restaurant restaurant, Reservation reservation);

    /// <summary>
    /// Remove reservation
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="reservation"><see cref="Reservation"/> to remove</param>
    void RemoveReservation(Restaurant restaurant, Reservation reservation);

    /// <summary>
    /// Add service
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="service">New <see cref="Service"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void AddService(Restaurant restaurant, Service service, UserRole userRole);

    /// <summary>
    /// Remove service
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="service"><see cref="Service"/> to remove</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void RemoveService(Restaurant restaurant, Service service, UserRole userRole);

    /// <summary>
    /// Add menu item
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="menuItem">New <see cref="MenuItem"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void AddMenuItem(Restaurant restaurant, MenuItem menuItem, UserRole userRole);

    /// <summary>
    /// Remove menu item
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="menuItem"><see cref="MenuItem"/> to remove.</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void RemoveMenuItem(Restaurant restaurant, MenuItem menuItem, UserRole userRole);

    /// <summary>
    /// Add daily employee schedule
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="dailyEmployeeSchedule">New <see cref="DailyEmployeeSchedule"/></param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void AddDailyEmployeeSchedule(Restaurant restaurant, DailyEmployeeSchedule dailyEmployeeSchedule,
        UserRole userRole);

    /// <summary>
    /// Remove daily employee schedule
    /// </summary>
    /// <param name="restaurant"><see cref="Restaurant"/> instance</param>
    /// <param name="dailyEmployeeSchedule"><see cref="DailyEmployeeSchedule"/> to remove</param>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    void RemoveDailyEmployeeSchedule(Restaurant restaurant, DailyEmployeeSchedule dailyEmployeeSchedule,
        UserRole userRole);
}