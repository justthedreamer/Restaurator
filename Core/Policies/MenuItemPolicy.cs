using Core.Policies.Abstraction;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

/// <summary>
/// Menu item policy implementation
/// </summary>
internal sealed class MenuItemPolicy : IMenuItemPolicy
{
    /// <summary>
    /// Permitted roles to manage menu items.
    /// </summary>
    private static readonly UserRole[] PermittedRoles = [UserRole.Owner, UserRole.Manager];

    /// <summary>
    /// Check if request user is permitted role to manage menu items.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    public bool IsInRoleToManageMenuItem(UserRole userRole) => PermittedRoles.Any(role => role == userRole);
}