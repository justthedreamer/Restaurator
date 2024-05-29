using Core.Model.RestaurantModel;
using Core.Utilities;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Model.StaffModel;

/// <summary>
/// Represents restaurant owner.
/// </summary>
public class Owner : User
{
    public IReadOnlyList<Restaurant> Restaurants { get; private set; } = new List<Restaurant>();

    /// <summary>
    /// Add new restaurant to list.
    /// </summary>
    /// <param name="restaurant">New restaurant</param>
    internal void AddRestaurant(Restaurant restaurant) => Restaurants = Restaurants.AddItem(restaurant);

    /// <summary>
    /// Removes restaurant from list.
    /// </summary>
    /// <param name="restaurant">Restaurant to remove.</param>
    internal void RemoveRestaurant(Restaurant restaurant) => Restaurants = Restaurants.RemoveItem(restaurant);

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Owner() : base()
    {
    }

    /// <summary>
    /// Base constructor call
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userRole">Role</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="credentials">Credentials</param>
    public Owner(UserId userId, UserRole userRole, FirstName firstName, LastName lastName, Credentials credentials) : base(
        userId, userRole, firstName, lastName, credentials)
    {
    }
}