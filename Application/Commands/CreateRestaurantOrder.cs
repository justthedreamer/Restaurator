using ICommand = Application.Commands.Abstraction.ICommand;

namespace Application.Commands;

public sealed record CreateRestaurantOrder : ICommand
{
    public Guid OrderId { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid TableId { get; set; }
    public List<Guid>? MenuItems { get; set; }
    public List<Guid>? Services { get; set; }
}