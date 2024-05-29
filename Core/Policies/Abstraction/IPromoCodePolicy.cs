using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

public interface IPromoCodePolicy
{
    /// <summary>
    /// Check if requesting user is permitted.
    /// </summary>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <returns>True or false</returns>
    bool IsInRole(UserRole userRole);
}