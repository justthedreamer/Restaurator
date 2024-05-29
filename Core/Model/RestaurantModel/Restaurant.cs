using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.ReservationModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.Model.StaffModel;
using Core.Utilities;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;

namespace Core.Model.RestaurantModel;

/// <summary>
/// Represent Restaurant
/// </summary>
public class Restaurant
{
    public RestaurantId RestaurantId { get; private set; }
    public Owner Owner { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyList<PhoneNumber> PublicPhoneNumbers { get; private set; } = new List<PhoneNumber>();
    public IReadOnlyList<Email> PublicEmails { get; private set; } = new List<Email>();
    public IReadOnlyList<Table> Tables { get; private set; } = new List<Table>();
    public IReadOnlyList<Order> Orders { get; private set; } = new List<Order>();
    public IReadOnlyList<Employee> Employees { get; set; } = new List<Employee>();
    public IReadOnlyList<Reservation> Reservations { get; private set; } = new List<Reservation>();
    public IReadOnlyList<DailyEmployeeSchedule> Schedules { get; private set; } = new List<DailyEmployeeSchedule>();
    public IReadOnlyList<Service> Services { get; private set; } = new List<Service>();
    public Menu Menu { get; private set; }

    /// <summary>
    /// Add public phone number
    /// </summary>
    /// <param name="phoneNumber">New phone number</param>
    internal void AddPublicPhoneNumber(PhoneNumber phoneNumber) =>
        PublicPhoneNumbers = PublicPhoneNumbers.AddItem(phoneNumber);

    /// <summary>
    /// Remove public phone number
    /// </summary>
    /// <param name="phoneNumber">Phone number to remove</param>
    internal void RemovePublicPhoneNumber(PhoneNumber phoneNumber) =>
        PublicPhoneNumbers = PublicPhoneNumbers.RemoveItem(phoneNumber);

    /// <summary>
    /// Add new public email
    /// </summary>
    /// <param name="email">New public email</param>
    internal void AddPublicEmail(Email email) => PublicEmails = PublicEmails.AddItem(email);

    /// <summary>
    /// Remove public email
    /// </summary>
    /// <param name="email">Email to remove</param>
    internal void RemovePublicEmail(Email email) => PublicEmails = PublicEmails.RemoveItem(email);

    /// <summary>
    /// Add new table
    /// </summary>
    /// <param name="table">New table</param>
    internal void AddTable(Table table) => Tables = Tables.AddItem(table);

    /// <summary>
    /// Remove table
    /// </summary>
    /// <param name="table">Table to remove</param>
    internal void RemoveTable(Table table) => Tables = Tables.RemoveItem(table);

    /// <summary>
    /// Add new order
    /// </summary>
    /// <param name="order">New order</param>
    internal void AddOrder(Order order) => Orders = Orders.AddItem(order);

    /// <summary>
    /// Remove order
    /// </summary>
    /// <param name="order">Order to remove</param>
    internal void RemoveOrder(Order order) => Orders = Orders.RemoveItem(order);

    /// <summary>
    /// Add new employee
    /// </summary>
    /// <param name="employee">New employee</param>
    internal void AddEmployee(Employee employee) => Employees = Employees.AddItem(employee);

    /// <summary>
    /// Remove employee
    /// </summary>
    /// <param name="employee">Employee to remove</param>
    internal void RemoveEmployee(Employee employee) => Employees = Employees.RemoveItem(employee);

    /// <summary>
    /// Add reservation
    /// </summary>
    /// <param name="reservation">New reservation</param>
    internal void AddReservation(Reservation reservation) => Reservations = Reservations.AddItem(reservation);

    /// <summary>
    /// Remove reservation
    /// </summary>
    /// <param name="reservation">Reservation to remove</param>
    internal void RemoveReservation(Reservation reservation) => Reservations = Reservations.RemoveItem(reservation);

    /// <summary>
    /// Add service
    /// </summary>
    /// <param name="service">New service</param>
    internal void AddService(Service service) => Services = Services.AddItem(service);

    /// <summary>
    /// Remove service
    /// </summary>
    /// <param name="service">Service to remove</param>
    internal void RemoveService(Service service) => Services = Services.RemoveItem(service);

    /// <summary>
    /// Add daily employee schedule
    /// </summary>
    /// <param name="dailyEmployeeSchedule">New schedule</param>
    internal void AddDailyEmployeeSchedule(DailyEmployeeSchedule dailyEmployeeSchedule) =>
        Schedules = Schedules.AddItem(dailyEmployeeSchedule);

    /// <summary>
    /// Remove daily employee schedule
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Schedule to remove</param>
    internal void RemoveDailyEmployeeSchedule(DailyEmployeeSchedule dailyEmployeeSchedule) =>
        Schedules = Schedules.RemoveItem(dailyEmployeeSchedule);

    /// <summary>
    /// Change restaurant address
    /// </summary>
    /// <param name="address">New address</param>
    internal void ChangeRestaurantAddress(Address address) => Address = address;

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Restaurant()
    {
    }

    /// <summary>
    /// Self constructor
    /// </summary>
    /// <param name="restaurantId">Restaurant ID</param>
    /// <param name="owner">Owner</param>
    /// <param name="address">Address</param>
    /// <param name="menu">Menu</param>
    public Restaurant(RestaurantId restaurantId, Owner owner, Address address, Menu menu)
    {
        RestaurantId = restaurantId;
        Owner = owner;
        Address = address;
        Menu = menu;
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="restaurantId">Restaurant ID</param>
    /// <param name="owner">Owner</param>
    /// <param name="address">Address</param>
    /// <param name="publicPhoneNumbers">Public phone numbers</param>
    /// <param name="publicEmails">Public email addresses</param>
    public Restaurant(Guid restaurantId, Owner owner, Address address, List<PhoneNumber> publicPhoneNumbers,
        List<Email> publicEmails)
    {
        RestaurantId = restaurantId;
        Owner = owner;
        Address = address;
        PublicPhoneNumbers = publicPhoneNumbers;
        PublicEmails = publicEmails;
        Menu = new Menu(Guid.NewGuid());
    }
}