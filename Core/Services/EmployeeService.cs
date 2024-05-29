using System.Runtime.CompilerServices;
using Core.Exceptions.Policies;
using Core.Model.StaffModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

[assembly: InternalsVisibleTo("CoreUnitTests")]
namespace Core.Services;

/// <summary>
/// Employee service
/// </summary>
/// <param name="employeePolicy">Employee Policy</param>
internal class EmployeeService(IEmployeePolicy employeePolicy) : IEmployeeService
{
    /// <summary>
    /// Change employee full name
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="userRole">Requesting user role.</param>
    public void ChangeEmployeeName(Employee employee, FirstName firstName, LastName lastName, UserRole userRole)
    {
        var isInRole = employeePolicy.IsInRoleToChangeName(userRole);
        
        if (!isInRole)
            throw new PolicyNoPermissionsException();
        
        employee.ChangeEmployeeName(firstName,lastName);
    }

    /// <summary>
    /// Change employee position
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="newPosition">New position</param>
    /// <param name="userRole">Requesting user role</param>
    public void ChangeEmployeePosition(Employee employee, EmployeePosition newPosition, UserRole userRole)
    {
        var isInRole = employeePolicy.IsInRoleToChangePosition(userRole);
        
        if (!isInRole)
            throw new PolicyNoPermissionsException();
        
        employee.ChangePosition(newPosition);
    }

    /// <summary>
    /// Change employee email
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="email">New email</param>
    /// <param name="userRole">Requesting user role</param>
    public void ChangeEmployeeEmail(Employee employee, Email email, UserRole userRole)
    {
        var isInRole = employeePolicy.IsInRoleToChangeEmail(userRole);
        
        if (!isInRole)
            throw new PolicyNoPermissionsException();
        
        employee.Credentials.ChangeEmail(email);
    }

    /// <summary>
    /// Change employee password
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="password">New password</param>
    /// <param name="userRole">Requesting user role</param>
    public void ChangeEmployeePassword(Employee employee, Password password, UserRole userRole)
    {
        var isInRole = employeePolicy.IsInRoleToChangePassword(userRole);
        
        if (!isInRole)
            throw new PolicyNoPermissionsException();
        
        employee.Credentials.ChangePassword(password);
    }
}