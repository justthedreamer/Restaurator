using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;

namespace Application.DTO;

public sealed class MenuItemDto
{
    public required MenuItemId Id { get; init; }
    public required MenuItemName Name { get; init; }
    public required MenuItemCategory Category { get; init; }
    public required Price Price { get; init; }
    public MenuItemDescription? Description { get; init; }
    public PrepareTime? PrepareTime { get; init; }
    public required IEnumerable<string> Ingredients { get; init; }
}
