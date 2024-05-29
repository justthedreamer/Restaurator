using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Menu item policy interface
/// </summary>
public interface IMenuItemPolicy
{
    /// <summary>
    /// Check if request user is permitted role to manage menu items.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsInRoleToManageMenuItem(UserRole userRole);
}