using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Restaurant policy interface
/// </summary>
internal interface IRestaurantPolicy
{
    /// <summary>
    /// Check if requesting user is permitted to do changes.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToManageRestaurantInformation(UserRole userRole);

    /// <summary>
    /// Check if requesting user is permitted to do manage public information.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToMagePublicInfo(UserRole userRole);

    /// <summary>
    /// Check if requesting user is permitted to manage tables.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToManageTables(UserRole userRole);

    /// <summary>
    /// Check if requesting user is permitted to manage services.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToManageServices(UserRole userRole);

    /// <summary>
    /// Check if requesting user is permitted to manage menu items.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToManageMenuItems(UserRole userRole);

    /// <summary>
    /// Check if requesting user is permitted to manage daily employee schedules.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsPermittedToManageDailySchedules(UserRole userRole);
}