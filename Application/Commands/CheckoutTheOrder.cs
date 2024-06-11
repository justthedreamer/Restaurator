using Application.Commands.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Commands;

public sealed record CheckoutTheOrder : ICommand
{
    public Guid RestaurantId { get; set; }
    public Guid OrderId { get; set; }
    public required string PaymentMethod { get; set; }
}