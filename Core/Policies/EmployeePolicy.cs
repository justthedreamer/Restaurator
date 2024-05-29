using Core.Policies.Abstraction;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

/// <summary>
/// Employee policy implementation
/// </summary>
internal class EmployeePolicy : IEmployeePolicy
{
    private static UserRole[] RolesToChangeName = [UserRole.Owner];
    private static UserRole[] RolesToChangePosition = [UserRole.Owner,UserRole.Manager];
    private static UserRole[] RolesToChangeEmail = [UserRole.Owner,UserRole.Employee];
    private static UserRole[] RolesToChangePassword = [UserRole.Employee];

    public bool IsInRoleToChangeName(UserRole userRole) => RolesToChangeName.Any(role => role == userRole);

    public bool IsInRoleToChangePosition(UserRole userRole) => RolesToChangePosition.Any(role => role == userRole);

    public bool IsInRoleToChangeEmail(UserRole userRole) => RolesToChangeEmail.Any(role => role == userRole);

    public bool IsInRoleToChangePassword(UserRole userRole) => RolesToChangePassword.Any(role => role == userRole);
}