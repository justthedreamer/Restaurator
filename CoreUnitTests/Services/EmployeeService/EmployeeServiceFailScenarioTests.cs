using Core.Exceptions.Policies;
using Core.Policies;
using Core.Services;
using Core.Services.Abstraction;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services;

public class EmployeeServiceFailScenarioTests
{
    [Theory]
    [InlineData(UserRole.Employee)]
    [InlineData(UserRole.Manager)]
    public void change_employee_name_with_invalid_role_should_throw_policy_no_permissions_exception(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var firstName = "John";
        var lastName = "Paulo";

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _employeeService.ChangeEmployeeName(employee,firstName,lastName,userRole);

        });
    }
    
    [Theory]
    [InlineData(UserRole.Employee)]
    public void change_employee_position_with_invalid_role_should_throw_policy_no_permissions_exception(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newPosition = EmployeePosition.Manager;

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _employeeService.ChangeEmployeePosition(employee,newPosition,userRole);

        });
    }
    
    [Theory]
    [InlineData(UserRole.Manager)]
    public void change_employee_email_with_invalid_role_should_throw_policy_no_permissions_exception(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newEmail = "email2@email.com";

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _employeeService.ChangeEmployeeEmail(employee,newEmail,userRole);

        });
    }
    
    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void change_employee_password_with_invalid_role_should_throw_policy_no_permissions_exception(UserRole userRole)
    {
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var newPassword = "password2";

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _employeeService.ChangeEmployeePassword(employee,newPassword,userRole);

        });
    }
    
    private readonly IEmployeeService _employeeService = new EmployeeService(new EmployeePolicy());
}