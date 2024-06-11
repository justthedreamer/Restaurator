using Core.Model.ServicesModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Restaurant;

namespace Core.Model.MenuModel;

/// <summary>
/// Represents restaurant menu.
/// </summary>
public class Menu
{
    public MenuId MenuId { get; private set; } = default!;
    public List<MenuItem> MenuItems { get; private set; } = new();
    
    internal void AddMenuItem(MenuItem menuItem) => MenuItems.Add(menuItem);
    internal void RemoveMenuItem(MenuItem menuItem) => MenuItems.Remove(menuItem);
    
    /// <summary>
    /// Empty constructor for entity framework.
    /// </summary>
    private Menu()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="menuId">Menu ID</param>
    public Menu(MenuId menuId)
    {
        MenuId = menuId;
    }
}