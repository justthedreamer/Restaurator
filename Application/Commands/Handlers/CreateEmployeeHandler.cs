using Application.Commands.Abstraction;
using Application.Security;
using Core.Model.StaffModel;
using Core.Repositories;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

internal sealed class CreateEmployeeHandler(IEmployeeRepository employeeRepository,IPasswordManager passwordManager): ICommandHandler<CreateEmployee>
{
    public async Task HandleAsync(CreateEmployee command)
    {
        var restaurantId = new RestaurantId(command.RestaurantId);
        var userId = new UserId(command.EmployeeId);
        var email = new Email(command.Email);
        var password = new Password(passwordManager.Secure(command.Password));
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.LastName);
        var position = new EmployeePosition(command.Position.ToUpper());
        var phoneNumber = new PhoneNumber(command.PhoneNumber);
        var role = new UserRole(UserRole.Employee);

        var loginPrototype = await employeeRepository.GetAvailableLogin(restaurantId, firstName, lastName);
        var login = new EmployeeLogin(loginPrototype);
        
        var employee = new Employee(userId, login, firstName, lastName, new Credentials(email, password), position, role,
            phoneNumber){RestaurantId = restaurantId};

        await employeeRepository.AddEmployeeAsync(employee);
    }
}