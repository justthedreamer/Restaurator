using Application.DTO;
using Application.Queries.Abstraction;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantMenu : IQuery<MenuDto>
{
    public Guid RestaurantId { get; set; }
}
