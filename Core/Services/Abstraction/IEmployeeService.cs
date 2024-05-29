using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

public interface IEmployeeService
{
    /// <summary>
    /// Change employee full name
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="userRole">Requesting user role.</param>
    void ChangeEmployeeName(Employee employee, FirstName firstName, LastName lastName, UserRole userRole);

    /// <summary>
    /// Change employee position
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="newPosition">New position</param>
    /// <param name="userRole">Requesting user role</param>
    void ChangeEmployeePosition(Employee employee, EmployeePosition newPosition, UserRole userRole);

    /// <summary>
    /// Change employee email
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="email">New email</param>
    /// <param name="userRole">Requesting user role</param>
    void ChangeEmployeeEmail(Employee employee, Email email, UserRole userRole);

    /// <summary>
    /// Change employee password
    /// </summary>
    /// <param name="employee">Employee</param>
    /// <param name="password">New password</param>
    /// <param name="userRole">Requesting user role</param>
    void ChangeEmployeePassword(Employee employee, Password password,UserRole userRole);
}