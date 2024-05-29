using Core.Model.StaffModel;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Employee policy interface
/// </summary>
public interface IEmployeePolicy
{
    /// <summary>
    /// Check if requesting user is in permitted role to action.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsInRoleToChangeName(UserRole userRole);

    /// <summary>
    /// Check if requesting user is in permitted role to action.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsInRoleToChangePosition(UserRole userRole);

    
    /// <summary>
    /// Check if requesting user is in permitted role to action.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsInRoleToChangeEmail(UserRole userRole);

    /// <summary>
    /// Check if requesting user is in permitted role to action.
    /// </summary>
    /// <param name="userRole">Requesting user role</param>
    /// <returns>True or false</returns>
    bool IsInRoleToChangePassword(UserRole userRole);
}