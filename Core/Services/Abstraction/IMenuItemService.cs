using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

/// <summary>
/// Menu item service interface
/// </summary>
public interface IMenuItemService
{
    /// <summary>
    /// Update menu item category
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="menuItemCategory">New category</param>
    /// <param name="userRole">Requesting user role</param>
    void UpdateMenuItemCategory(MenuItem menuItem, MenuItemCategory menuItemCategory, UserRole userRole);

    /// <summary>
    /// Change menu item price
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="price">New price</param>
    /// <param name="userRole">Requesting user role</param>
    void ChangeMenuItemPrice(MenuItem menuItem, Price price, UserRole userRole);

    /// <summary>
    /// Add ingredient
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="ingredient">New ingredient</param>
    /// <param name="userRole">Requesting user role</param>
    void AddIngredient(MenuItem menuItem, Ingredient ingredient, UserRole userRole);

    /// <summary>
    /// Remove ingredient
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="ingredient">Ingredient to remove</param>
    /// <param name="userRole">Requesting user role</param>
    void RemoveIngredient(MenuItem menuItem, Ingredient ingredient, UserRole userRole);

    /// <summary>
    /// Update menu item description
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="description">New description</param>
    /// <param name="userRole">Requesting user role</param>
    void UpdateMenuItemDescription(MenuItem menuItem, MenuItemDescription description, UserRole userRole);

    /// <summary>
    /// Remove menu item description
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="userRole">Requesting user role</param>
    void RemoveMenuItemDescription(MenuItem menuItem, UserRole userRole);

    /// <summary>
    /// Update prepare time
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="prepareTime">New prepare time</param>
    /// <param name="userRole">Requesting user role</param>
    void UpdatePrepareTime(MenuItem menuItem, PrepareTime prepareTime, UserRole userRole);

    /// <summary>
    /// Remove prepare time
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="userRole">Requesting user role</param>
    void RemovePrepareTime(MenuItem menuItem, UserRole userRole);
}