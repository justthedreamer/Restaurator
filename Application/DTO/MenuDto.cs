using System.Collections;

namespace Application.DTO;

public sealed class MenuDto
{
    public required IEnumerable<MenuItemDto> MenuItems { get; set; }
    public required IEnumerable<ServiceDto> Services { get; init; }
}