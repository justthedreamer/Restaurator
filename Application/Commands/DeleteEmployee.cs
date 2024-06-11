using System.Windows.Input;
using ICommand = Application.Commands.Abstraction.ICommand;

namespace Application.Commands;

public sealed class DeleteEmployee : ICommand
{
    public required Guid RestaurantId { get; init; }
    public required Guid EmployeeId { get; set; }
}