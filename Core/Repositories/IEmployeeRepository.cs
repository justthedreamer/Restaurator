using Core.Model.StaffModel;
using Core.ValueObject.Staff.Employee;

namespace Core.Repositories;

/// <summary>
/// Employee repository interface
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Get employee by its login.
    /// </summary>
    /// <param name="employeeLogin">Employee login</param>
    /// <returns>Employee entity or null if not found.</returns>
    Task<Employee?> GetEmployeeByLogin(EmployeeLogin employeeLogin);

    /// <summary>
    /// Update employee profile
    /// </summary>
    /// <param name="employee">Employee instance</param>
    Task UpdateAsync(Employee employee);
}