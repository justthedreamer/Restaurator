using Core.Model.StaffModel;
using Core.Repositories;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Implementation of employee repository.
/// </summary>
/// <param name="dbContext"></param>
internal class EmployeeRepository(RestauratorDbContext dbContext) : IEmployeeRepository
{
    private readonly DbSet<Employee> _employees = dbContext.Employees;

    /// <summary>
    /// Get employee by id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Employee entity or null if not found.</returns>
    public async Task<Employee?> GetEmployeeAsync(UserId userId)
    {
        var employee = await _employees.SingleOrDefaultAsync(e => e.UserId == userId);
        return employee;
    }

    /// <summary>
    /// Get employee by its login.
    /// </summary>
    /// <param name="employeeLogin">Employee login</param>
    /// <returns>Employee entity or null if not found.</returns>
    public async Task<Employee?> GetEmployeeByLoginAsync(EmployeeLogin employeeLogin)
    {
        var employee = await _employees.SingleOrDefaultAsync(x => x.EmployeeLogin == employeeLogin);
        return employee;
    }

    /// <summary>
    /// Update employee profile
    /// </summary>
    /// <param name="employee">Employee instance</param>
    public async Task UpdateAsync(Employee employee)
    {
        _employees.Update(employee);
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Add new employee
    /// </summary>
    /// <param name="employee">Employee instance</param>
    public async Task AddEmployeeAsync(Employee employee)
    {
        await _employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Returns available login for new user.
    /// </summary>
    /// <param name="firstName">New employee first name</param>
    /// <param name="lastName">New employee last name</param>
    /// <returns>Unique login</returns>
    public async Task<string> GetAvailableLogin(RestaurantId restaurantId, FirstName firstName, LastName lastName)
    {
        var loginPrototype = firstName.Value + '.' + lastName.Value;

        var employees = await _employees.Where(e => e.RestaurantId == restaurantId).ToListAsync();

        var logins = employees.Where(e => e.EmployeeLogin.Value.Contains(loginPrototype)).ToList();

        if (logins.Any())
        {
            return $"{loginPrototype}{logins.Count + 1}";
        }

        return loginPrototype;
    }

    /// <summary>
    /// Delete employee
    /// </summary>
    /// <param name="employee">Employee entity</param>
    public async Task DeleteAsync(Employee employee)
    {
        _employees.Remove(employee);
        await dbContext.SaveChangesAsync();
    }
}