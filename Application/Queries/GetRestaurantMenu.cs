using Application.DTO;
using Application.Queries.Abstraction;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantMenu(Guid RestaurantId) : IQuery<MenuDto>{}
