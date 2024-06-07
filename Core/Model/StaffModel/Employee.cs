using System.Security.AccessControl;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Model.StaffModel;

/// <summary>
/// Represents restaurant employee.
/// </summary>
public class Employee : User, ISoftDelete
{
    public EmployeeLogin EmployeeLogin { get; private set; }
    public EmployeePosition EmployeePosition { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; } //todo
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Change first name
    /// </summary>
    /// <param name="firstName">New first name</param>
    /// <param name="lastName">New last name</param>
    internal void ChangeEmployeeName(FirstName firstName, LastName lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// Change position
    /// </summary>
    /// <param name="employeePosition">New position</param>
    internal void ChangePosition(EmployeePosition employeePosition) => EmployeePosition = employeePosition;

    /// <summary>
    /// Mark object as deleted.
    /// </summary>
    public void SoftDelete()
    {
        IsDeleted = true;
    }
    
    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Employee()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="employeeLogin">Employee login</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="credentials">Credentials</param>
    /// <param name="employeePosition">Position</param>
    /// <param name="phoneNumber">Phone number</param>
    public Employee(UserId userId,EmployeeLogin employeeLogin, FirstName firstName, LastName lastName, Credentials credentials,
        EmployeePosition employeePosition,PhoneNumber phoneNumber) : base(userId, UserRole.Employee, firstName, lastName, credentials)
    {
        EmployeeLogin = employeeLogin;
        EmployeePosition = employeePosition;
        PhoneNumber = phoneNumber;
    }

   
}