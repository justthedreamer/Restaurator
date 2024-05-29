using Core.Exceptions.Policies;
using Core.Policies.Abstraction;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

/// <summary>
/// Service policy implementation
/// </summary>
public class ServicePolicy : IServicePolicy
{
    private static readonly UserRole[] PermittedRoles = [UserRole.Owner, UserRole.Manager];

    public bool IsPermitted(UserRole userRole) => PermittedRoles.Any(role => role == userRole);
}