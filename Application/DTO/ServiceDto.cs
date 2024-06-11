using System.Reflection.Metadata.Ecma335;
using Core.ValueObject.Price;
using Core.ValueObject.Service;

namespace Application.DTO;

public sealed class ServiceDto
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
}