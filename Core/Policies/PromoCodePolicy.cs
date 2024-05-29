using Core.Policies.Abstraction;
using Core.ValueObject.Price;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

internal sealed class PromoCodePolicy : IPromoCodePolicy
{
    private static readonly UserRole[] PermittedRoles = [UserRole.Owner, UserRole.Manager,];

    /// <summary>
    /// Check if requesting user is permitted.
    /// </summary>
    /// <param name="userRole">Requesting user role.<see cref="UserRole"/></param>
    /// <returns>True or false</returns>
    public bool IsInRole(UserRole userRole) => PermittedRoles.Any(x => x == userRole);
}