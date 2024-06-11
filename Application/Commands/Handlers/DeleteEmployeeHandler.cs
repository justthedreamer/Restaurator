using Application.Commands.Abstraction;
using Application.Exceptions;
using Core.Repositories;
using Core.ValueObject.Staff.User;

namespace Application.Commands.Handlers;

public class DeleteEmployeeHandler(IEmployeeRepository repository) : ICommandHandler<DeleteEmployee>
{
    public async Task HandleAsync(DeleteEmployee command)
    {
        var userId = new UserId(command.EmployeeId);
        var employee = await repository.GetEmployeeAsync(userId);

        if (employee is null)
        {
            throw new EmployeeNotFoundException();
        }

        await repository.DeleteAsync(employee);
    }
}