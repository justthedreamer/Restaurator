using Application.Commands.Abstraction;

namespace Application.Commands;

public sealed record CreateDeliveryOrder : ICommand
{
    public Guid OrderId { get; set; }
    public Guid RestaurantId { get; set; }
    public required List<Guid> MenuItems { get; set; }
    public required List<Guid> Services { get; set; }
    public required string CustomerFirstName { get; set; }
    public required string CustomerLastName { get; set; }
    public required string CustomerCity { get; set; }
    public required string CustomerStreet { get; set; }
    public required string CustomerHouseNumber { get; set; }
    public required string CustomerPhoneNumber { get; set; }
}