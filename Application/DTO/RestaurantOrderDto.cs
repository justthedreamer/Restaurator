using Core.ValueObject.Restaurant;

namespace Application.DTO;

public sealed class RestaurantOrderDto : OrderDto
{
    public required string TableSign { get; init; }
}