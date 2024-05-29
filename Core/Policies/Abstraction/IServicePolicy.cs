using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Service policy interface
/// </summary>
public interface IServicePolicy
{
    /// <summary>
    /// Check if requesting user is permitted to do changes.
    /// </summary>
    /// <param name="userRole">Requesting User role</param>
    /// <returns></returns>
    bool IsPermitted(UserRole userRole);
}