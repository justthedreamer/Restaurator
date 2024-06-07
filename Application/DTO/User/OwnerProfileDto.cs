namespace Application.DTO;

public sealed record OwnerProfileDto(OwnerDto OwnerDto, IEnumerable<RestaurantProfileDto> Restaurants);
