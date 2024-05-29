using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;

namespace CoreUnitTests.Utilities;

/// <summary>
/// Test menu item factory
/// </summary>
public static class MenuItemFactory
{
    /// <summary>
    /// Create menu item. <br />
    /// </summary>
    /// <returns>
    /// New <see cref="MenuItem"/> instance with properties:<br/>
    /// <i>
    /// ID : Guid <br/>
    /// Category : "Category" <br/>
    /// Description : "Description" <br/>
    /// Price : 100 <br/>
    /// Prepare Time : "10 min" </i><br/>
    /// </returns>
    public static MenuItem CreateMenuItem()
    {
        var id = Guid.NewGuid();
        var category = "Category";
        var price = new Price(100);
        var description = "Description";
        var prepareTime = new PrepareTime("10 min");

        var menuItem = new MenuItem(id, category, price, description, prepareTime);

        return menuItem;
    }
}