using Core.Model.StaffModel;
using Core.Repositories;
using Core.ValueObject.Staff.Employee;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class EmployeeRepository(RestauratorDbContext dbContext) : IEmployeeRepository
{
    private readonly DbSet<Employee> _employees = dbContext.Employees;

    public async Task<Employee?> GetEmployeeByLogin(EmployeeLogin employeeLogin)
    {
        var employee = await _employees.SingleOrDefaultAsync(x => x.EmployeeLogin == employeeLogin);
        return employee;
    }

    public async Task UpdateAsync(Employee employee)
    {
        _employees.Update(employee);
        await dbContext.SaveChangesAsync();
    }
}