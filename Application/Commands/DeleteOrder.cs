using System.Reflection.Metadata.Ecma335;
using Application.Commands.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Commands;

public sealed class DeleteOrder : ICommand
{
    public required Guid RestaurantId { get; set; }
    public required Guid OrderId { get; set; }
}