using Core.Policies.Abstraction;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

internal sealed class RestaurantPolicy : IRestaurantPolicy
{
    /// <summary>
    /// Check if requesting user is permitted to do changes.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToManageRestaurantInformation(UserRole userRole) => userRole == UserRole.Owner;

    /// <summary>
    /// Check if requesting user is permitted to do manage public information.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToMagePublicInfo(UserRole userRole) =>
        userRole == UserRole.Owner || userRole == UserRole.Manager;

    /// <summary>
    /// Check if requesting user is permitted to manage tables.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToManageTables(UserRole userRole)
    {
        return userRole == UserRole.Owner || userRole == UserRole.Manager;
    }

    /// <summary>
    /// Check if requesting user is permitted to manage services.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToManageServices(UserRole userRole)
    {
        return userRole == UserRole.Owner || userRole == UserRole.Manager;
    }

    /// <summary>
    /// Check if requesting user is permitted to manage menu items.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToManageMenuItems(UserRole userRole)
    {
        return userRole == UserRole.Owner || userRole == UserRole.Manager;
    }

    /// <summary>
    /// Check if requesting user is permitted to manage daily employee schedules.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsPermittedToManageDailySchedules(UserRole userRole)
    {
        return userRole == UserRole.Owner || userRole == UserRole.Manager;

    }
}