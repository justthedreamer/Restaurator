using System.Windows.Input;
using ICommand = Application.Commands.Abstraction.ICommand;

namespace Application.Commands;

public sealed record class CreateTakeAwayOrder : ICommand
{
    public Guid OrderId { get; set; }
    public Guid RestaurantId { get; set; }
    public required List<Guid> MenuItems { get; set; }
    public required List<Guid> Services { get; set; }
    public required string CustomerFirstName { get; set; }
    public required string CustomerLastName { get; set; }
}