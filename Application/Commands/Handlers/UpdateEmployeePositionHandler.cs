using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

public class UpdateEmployeePositionHandler(IEmployeeRepository employeeRepository,IEmployeeService employeeService) : ICommandHandler<UpdateEmployeePosition>
{
    public async Task HandleAsync(UpdateEmployeePosition command)
    {

        var employeeId = new UserId(command.EmployeeId);
        var position = new EmployeePosition(command.Position);
        
        var employee = await employeeRepository.GetEmployeeAsync(employeeId);

        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }
        
        employeeService.ChangeEmployeePosition(employee,position,command.RequestingUserRole);
        await employeeRepository.UpdateAsync(employee);
    }
}