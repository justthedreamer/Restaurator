using Core.ValueObject.Menu;
using Core.ValueObject.Price;

namespace Core.Model.MenuModel;

/// <summary>
/// Represents menu item.
/// </summary>
public class MenuItem : ISoftDelete
{
    public MenuItemId MenuItemId { get; private set; } = default!;
    public MenuItemName MenuItemName { get; private set; }
    public MenuItemCategory Category { get; private set; } = default!;
    public Price RetailPrice { get; private set; } = default!;
    public List<Ingredient> Ingredients { get; private set; } = new();
    public MenuItemDescription? Description { get; private set; }
    public PrepareTime? PrepareTime { get; private set; }
    public bool IsDeleted { get; set; } = false;

    internal void ChangeCategory(MenuItemCategory menuItemCategory) => Category = menuItemCategory;
    internal void ChangeRetailPrice(Price price) => RetailPrice = price;
    internal void AddIngredient(Ingredient ingredient) => Ingredients.Add(ingredient);
    internal void RemoveIngredient(Ingredient ingredient) => Ingredients.Remove(ingredient);
    internal void UpdateDescription(MenuItemDescription menuItemDescription) => Description = menuItemDescription;
    internal void RemoveDescription() => Description = null;
    internal void UpdatePrepareTime(PrepareTime prepareTime) => PrepareTime = prepareTime;
    internal void RemovePrepareTime() => PrepareTime = null;
    
    /// <summary>
    /// Mark object as deleted.
    /// </summary>
    public void SoftDelete()
    {
        IsDeleted = true;
    }
    
    /// <summary>
    /// Empty constructor for entity framework.
    /// </summary>
    private MenuItem()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="menuItemId">Menu item ID</param>
    /// <param name="menuItemName">Menu item name</param>
    /// <param name="category">Menu item Category</param>
    /// <param name="retailPrice">Menu item Price</param>
    /// <param name="description">Menu item retail description</param>
    /// <param name="prepareTime">Estimated preparation time</param>
    /// <param name="ingredients">Ingredients list</param>
    public MenuItem(MenuItemId menuItemId,MenuItemName menuItemName, MenuItemCategory category, Price retailPrice, MenuItemDescription? description,
        PrepareTime? prepareTime, List<Ingredient>? ingredients = null)
    {
        MenuItemId = menuItemId;
        MenuItemName = menuItemName;
        Category = category;
        RetailPrice = retailPrice;
        Description = description;
        PrepareTime = prepareTime;
        if (ingredients is not null)
        {
            Ingredients = ingredients;
        }
    }

   
}