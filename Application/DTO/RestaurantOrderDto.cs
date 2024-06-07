using Core.ValueObject.Restaurant;

namespace Application.DTO;

public sealed class RestaurantOrderDto : OrderDto
{
    public required TableSign TableSign { get; init; }
}