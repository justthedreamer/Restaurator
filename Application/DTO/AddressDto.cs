namespace Application.DTO;

public sealed record AddressDto()
{
    public required string City { get; init; }
    public required string Street { get; init; }
    public required string HouseNumber { get; init; }
}