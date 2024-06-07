using Core.ValueObject.Price;
using Core.ValueObject.Service;

namespace Application.DTO;

public sealed class ServiceDto
{
    public ServiceName Name { get; init; }
    public Price Price { get; init; }
}