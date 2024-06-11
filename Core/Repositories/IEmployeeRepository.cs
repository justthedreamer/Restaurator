using Core.Model.StaffModel;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Core.Repositories;

/// <summary>
/// Employee repository interface
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Get employee by id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Employee entity or null if not found.</returns>
    Task<Employee?> GetEmployeeAsync(UserId userId);
    
    /// <summary>
    /// Get employee by its login.
    /// </summary>
    /// <param name="employeeLogin">Employee login</param>
    /// <returns>Employee entity or null if not found.</returns>
    Task<Employee?> GetEmployeeByLoginAsync(EmployeeLogin employeeLogin);

    /// <summary>
    /// Update employee profile
    /// </summary>
    /// <param name="employee">Employee instance</param>
    Task UpdateAsync(Employee employee);

    /// <summary>
    /// Add new employee
    /// </summary>
    /// <param name="employee">Employee instance</param>
    Task AddEmployeeAsync(Employee employee);

    /// <summary>
    /// Returns available login for new user.
    /// </summary>
    /// <param name="restaurantId">Restaurant Id</param>
    /// <param name="firstName">New employee first name</param>
    /// <param name="lastName">New employee last name</param>
    /// <returns>Unique login</returns>
    Task<string> GetAvailableLogin(RestaurantId restaurantId,FirstName firstName, LastName lastName);

    /// <summary>
    /// Delete employee
    /// </summary>
    /// <param name="employee">Employee entity</param>
    Task DeleteAsync(Employee employee);
}