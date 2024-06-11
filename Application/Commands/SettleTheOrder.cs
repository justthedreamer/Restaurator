using Application.Commands.Abstraction;

namespace Application.Commands;

public sealed record SettleTheOrder : ICommand
{
    public Guid RestaurantId { get; set; }
    public Guid OrderId { get; set; }
    public string? OrderMessage { get; set; }
}