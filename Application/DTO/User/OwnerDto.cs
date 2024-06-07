namespace Application.DTO;

public sealed record OwnerDto(Guid UserId, string FirstName, string LastName, string Email);