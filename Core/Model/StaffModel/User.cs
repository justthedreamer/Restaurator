using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Model.StaffModel;

/// <summary>
/// Represent application user
/// </summary>
public abstract class User
{
    public UserId UserId { get; protected set; }
    public UserRole UserRole { get; protected set; }
    public FirstName FirstName { get; protected set; }
    public LastName LastName { get; protected set; }
    public Credentials Credentials { get; protected set; }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected User()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="userRole">User role</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="credentials">Credentials</param>
    protected User(UserId userId, UserRole userRole, FirstName firstName, LastName lastName, Credentials credentials)
    {
        UserId = userId;
        UserRole = userRole;
        FirstName = firstName;
        LastName = lastName;
        Credentials = credentials;
    }
}