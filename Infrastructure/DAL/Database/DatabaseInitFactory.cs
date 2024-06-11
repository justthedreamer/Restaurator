using System.Collections;
using Application.Security;
using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.PromoCodeModel;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.Model.StaffModel;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Reservation;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Table = Core.Model.RestaurantModel.Table;

namespace Infrastructure.DAL.Database;

internal class DatabaseInitFactory(
    IPasswordManager passwordManager,
    IRestaurantService restaurantService,
    IScheduleService scheduleService)
{
    public Owner CreateOwner()
    {
        var ownerId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var ownerEmail = "john.doe@email.com";
        var ownerPassword = passwordManager.Secure("johndoe12345");

        var owner = new Owner(ownerId, UserRole.Owner, "John", "Doe", new Credentials(ownerEmail, ownerPassword));
        return owner;
    }


    public Restaurant CreateRestaurant(Owner owner)
    {
        var restaurantId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var menuItems = CreateMenuItems();
        var services = CreateServices();
        var tables = CreateTables().ToList();
        var employees = CreateEmployees().ToList();
        var reservations = CreateReservations(tables.First());

        var restaurant = new Restaurant(restaurantId, "John Doe Restaurant", owner,
            new Address("Warsaw", "Downtown", "101"));

        foreach (var employee in employees)
        {
            restaurant.AddEmployee(employee);
        }

        foreach (var menuItem in menuItems)
        {
            restaurantService.AddMenuItem(restaurant, menuItem, UserRole.Owner);
        }

        foreach (var service in services)
        {
            restaurantService.AddService(restaurant, service, UserRole.Owner);
        }

        foreach (var table in tables)
        {
            restaurantService.AddTable(restaurant, table, UserRole.Owner);
        }

        foreach (var reservation in reservations)
        {
            restaurantService.AddReservation(restaurant, reservation);
        }


        return restaurant;
    }

    private IEnumerable<Employee> CreateEmployees()
    {
        var chef = new Employee(Guid.NewGuid(), "john.doe", "John", "Doe",
            new Credentials("john.doe.chef@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Chef,
            UserRole.Employee, "123456789");

        var waiter = new Employee(Guid.NewGuid(), "john.doe1", "John", "Doe",
            new Credentials("john.doe.waiter@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Waiter,
            UserRole.Employee, "123456789");

        var manager = new Employee(Guid.NewGuid(), "john.doe2", "John", "Doe",
            new Credentials("john.doe.manager@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Manager,
            UserRole.Manager, "123456789");

        return new List<Employee>() { chef, waiter, manager };
    }

    private IEnumerable<MenuItem> CreateMenuItems()
    {
        var menuItemId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var menuItem = new MenuItem(menuItemId, "Fries", "Snacks", 5, "Crispy fires.", "15 minutes",
            new List<Ingredient>() { new Ingredient(Guid.NewGuid(), "Potato", "Vegetables", 1) });

        return new List<MenuItem>() { menuItem };
    }


    private IEnumerable<Service> CreateServices()
    {
        var serviceId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var service = new Service(serviceId, "Delivery", 15);
        return new List<Service>() { service };
    }

    private IEnumerable<Table> CreateTables()
    {
        var tableId = new TableId(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        var table = new Table(tableId, "A1", 4);
        return new List<Table>() { table };
    }

    private IEnumerable<Reservation> CreateReservations(Table table)
    {
        var reservationId = new ReservationId(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        var reservationDate = new ReservationDate(new DateTime(2024, 07, 18, 12, 0, 0));
        var reservationTime = new ReservationTime(2);
        var customerCount = new CustomerCount(4);
        var reservation = new Reservation(reservationId, table, "John", "Doe", reservationDate, reservationTime,
            customerCount);
        return new List<Reservation>() { reservation };
    }
}