using Application.Security;
using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.StaffModel;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Infrastructure.DAL.Database;

internal class DatabaseInitFactory(IPasswordManager passwordManager, IRestaurantService restaurantService)
{
    public Owner CreateOwner()
    {
        var ownerId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var ownerEmail = "john.doe@email.com";
        var ownerPassword = passwordManager.Secure("johndoe12345");

        var owner = new Owner(ownerId, UserRole.Owner, "John", "Doe", new Credentials(ownerEmail, ownerPassword));
        return owner;
    }

    public IEnumerable<MenuItem> CreateMenuItems()
    {
        var menuItem = new MenuItem(Guid.NewGuid(), "Fries", "Snacks", 5, "Crispy fires.", "15 minutes",
            new List<Ingredient>() { new Ingredient(Guid.NewGuid(), "Potato", "Vegetables", 1) });

        return new List<MenuItem>() { menuItem };
    }

    public Restaurant CreateRestaurant(Owner owner)
    {
        var restaurantId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        var menuItems = CreateMenuItems();
        var restaurant = new Restaurant(restaurantId, "John Doe Restaurant", owner,
            new Address("Warsaw", "Downtown", "101"), new List<PhoneNumber>() { "123456789" },
            new List<Email>() { "restaurant@mail.com" });

        var tableId = new TableId(Guid.Parse("00000000-0000-0000-0000-000000000001"));
        var table = new Table(tableId, "A1", 4);
        foreach (var menuItem in menuItems)
        {
            restaurantService.AddMenuItem(restaurant, menuItem, UserRole.Owner);
            restaurantService.AddTable(restaurant,table,UserRole.Owner);
        }

        return restaurant;
    }

    public IEnumerable<Employee> CreateEmployees()
    {
        var chef = new Employee(Guid.NewGuid(), "john.doe", "John", "Doe",
            new Credentials("john.doe.chef@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Chef,
            UserRole.Employee,"123456789");

        var waiter = new Employee(Guid.NewGuid(), "john.doe1", "John", "Doe",
            new Credentials("john.doe.waiter@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Waiter,
            UserRole.Employee,"123456789");

        var manager = new Employee(Guid.NewGuid(), "john.doe2", "John", "Doe",
            new Credentials("john.doe.manager@doe.com", passwordManager.Secure("johnDoe!@#")), EmployeePosition.Manager,
            UserRole.Manager,"123456789");

        return new List<Employee>() { chef, waiter, manager };
    }

    public DailyEmployeeSchedule CreateSchedule()
    {
        var id = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Now);
        var schedule = new DailyEmployeeSchedule(id, date);
        return schedule;
    }

    public IEnumerable<EmployeeSchedule> CreateDailyEmployeeSchedule(IEnumerable<Employee> employees)
    {
        var from = new TimeOnly(12, 0, 0);
        var to = new TimeOnly(18, 0, 0);
        var employeeSchedules = employees.Select(e =>
            EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), e, from, to, ScheduleState.Confirmed));
        return employeeSchedules;
    }
}