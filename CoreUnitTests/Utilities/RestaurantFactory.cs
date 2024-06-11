using Core.Model.AddressModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace CoreUnitTests.Utilities;

public static class RestaurantFactory
{
    /// <summary>
    /// Creates restaurant without Schedules,Employees,Reservations and Services.
    /// </summary>
    /// <returns></returns>
    public static Restaurant CreateRestaurant()
    {
        var restaurantId = Guid.NewGuid();
        var restaurantName = "Restaurant test";
        var owner = new Owner(Guid.NewGuid(),UserRole.Owner, "John", "Doe",new Credentials("adres@adres.com","password"));
        var address = new Address("Cracow", "Downtown", "15/14");
        var restaurant = new Restaurant(restaurantId,restaurantName, owner, address);

        return restaurant;
    }
    
    /// <summary>
    /// Creates restaurant without Schedules,Employees,Reservations and Services.
    /// </summary>
    /// <param name="restaurantId">Restaurant ID</param>
    /// <returns></returns>
    public static Restaurant CreateRestaurant(RestaurantId restaurantId)
    {
        var restaurantName = "Restaurant test";
        var owner = new Owner(Guid.NewGuid(),UserRole.Owner, "John", "Doe",new Credentials("adres@adres.com","password"));
        var address = new Address("Cracow", "Downtown", "15/14");
        var restaurant = new Restaurant(restaurantId,restaurantName, owner, address);

        return restaurant;
    }

    public static Restaurant CreateRestaurantWithOneScheduleWaitingForApproval(RestaurantId restaurantId,
        EmployeeScheduleDate from, EmployeeScheduleDate to)
    {
        var restaurant = CreateRestaurant(restaurantId);
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var schedule = EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), employee, from, to,
            ScheduleState.WaitingForApproval);

        return restaurant;
    }
}