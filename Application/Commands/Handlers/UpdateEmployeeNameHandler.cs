using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Staff.Employee;

namespace Application.Commands.Handlers;

internal sealed class UpdateEmployeeNameHandler(IEmployeeRepository repository,IEmployeeService employeeService) : ICommandHandler<UpdateEmployeeName>
{
    public async Task HandleAsync(UpdateEmployeeName command)
    {
        var firstName = new FirstName(command.FirstName);
        var lastName = new LastName(command.FirstName);
        var employee = await repository.GetEmployeeAsync(command.EmployeeId);

        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        employeeService.ChangeEmployeeName(employee,firstName,lastName,command.RequestingUserRole);
        await repository.UpdateAsync(employee);
    }
}