using Core.Policies;
using Core.Services;
using Core.Services.Abstraction;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services;

public class EmployeeServiceSuccessScenarioTests
{
    [Theory]
    [InlineData(UserRole.Owner)]
    public void change_employee_name_with_correct_data_and_role_should_success(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var firstName = "John";
        var lastName = "Paulo";
        
        _employeeService.ChangeEmployeeName(employee,firstName,lastName,userRole);
        
        employee.FirstName.Value.ShouldBe(firstName);
        employee.LastName.Value.ShouldBe(lastName);
    }
    
    [Theory]
    [InlineData(UserRole.Owner)]
    [InlineData(UserRole.Manager)]
    public void change_employee_position_with_correct_data_and_role_should_success(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newPosition = EmployeePosition.Cleaner;
        
        _employeeService.ChangeEmployeePosition(employee,newPosition,userRole);
        
        employee.EmployeePosition.Value.ShouldBe(newPosition);
    }
    
    [Theory]
    [InlineData(UserRole.Owner)]
    [InlineData(UserRole.Employee)]
    public void change_employee_email_with_correct_data_and_role_should_success(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newEmail = "email2@email.com";

        _employeeService.ChangeEmployeeEmail(employee, newEmail, userRole);
        
        employee.Credentials.Email.Value.ShouldBe(newEmail);
    }
    
    [Theory]
    [InlineData(UserRole.Employee)]
    public void change_employee_password_with_correct_data_and_role_should_success(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newPassword = "password2";

        _employeeService.ChangeEmployeePassword(employee, newPassword, userRole);
        
        employee.Credentials.Password.Value.ShouldBe(newPassword);
    }

    private readonly IEmployeeService _employeeService = new EmployeeService(new EmployeePolicy());
}