using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;

namespace Application.DTO;

public sealed class MenuItemDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Category { get; init; }
    public required decimal Price { get; init; }
    public string? Description { get; init; }
    public string? PrepareTime { get; init; }
    public required IEnumerable<string> Ingredients { get; init; }
}
