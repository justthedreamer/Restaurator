using System.Runtime.CompilerServices;
using Core.Exceptions.Policies;
using Core.Model.MenuModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;
using Core.ValueObject.Staff.User;

namespace Core.Services;

/// <summary>
/// Menu item policy
/// </summary>
internal class MenuItemService(IMenuItemPolicy menuItemPolicy) : IMenuItemService
{
    /// <summary>
    /// Update menu item category
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="menuItemCategory">New category</param>
    /// <param name="userRole">Requesting user role</param>
    public void UpdateMenuItemCategory(MenuItem menuItem, MenuItemCategory menuItemCategory, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.ChangeCategory(menuItemCategory);
    }

    /// <summary>
    /// Change menu item price
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="price">New price</param>
    /// <param name="userRole">Requesting user role</param>
    public void ChangeMenuItemPrice(MenuItem menuItem, Price price, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.ChangeRetailPrice(price);
    }

    /// <summary>
    /// Add ingredient
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="ingredient">New ingredient</param>
    /// <param name="userRole">Requesting user role</param>
    public void AddIngredient(MenuItem menuItem, Ingredient ingredient, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.AddIngredient(ingredient);
    }

    /// <summary>
    /// Remove ingredient
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="ingredient">Ingredient to remove</param>
    /// <param name="userRole">Requesting user role</param>
    public void RemoveIngredient(MenuItem menuItem, Ingredient ingredient, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.RemoveIngredient(ingredient);
    }

    /// <summary>
    /// Update menu item description
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="description">New description</param>
    /// <param name="userRole">Requesting user role</param>
    public void UpdateMenuItemDescription(MenuItem menuItem, MenuItemDescription description, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.UpdateDescription(description);
    }

    /// <summary>
    /// Remove menu item description
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="userRole">Requesting user role</param>
    public void RemoveMenuItemDescription(MenuItem menuItem, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.RemoveDescription();
    }

    /// <summary>
    /// Update prepare time
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="prepareTime">New prepare time</param>
    /// <param name="userRole">Requesting user role</param>
    public void UpdatePrepareTime(MenuItem menuItem, PrepareTime prepareTime, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.UpdatePrepareTime(prepareTime);
    }

    /// <summary>
    /// Remove prepare time
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <param name="userRole">Requesting user role</param>
    public void RemovePrepareTime(MenuItem menuItem, UserRole userRole)
    {
        var isInRole = menuItemPolicy.IsInRoleToManageMenuItem(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        menuItem.RemovePrepareTime();
    }
}