using Core.Model.MenuModel;
using Core.ValueObject.Price;

namespace Core.Model.FinancesModel;

public class MenuItemReceiptRow : ReceiptRow
{
    public MenuItem MenuItem { get; private set; } = null!;

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private MenuItemReceiptRow() : base()
    {
    }

    /// <summary>
    /// General constructor.
    /// </summary>
    /// <param name="menuItem">Menu item.</param>
    /// <param name="defaultPrice">Menu item default price.</param>
    /// <param name="finalPrice">Final price after applying promotional code.</param>
    public MenuItemReceiptRow(MenuItem menuItem,Price defaultPrice, Price finalPrice) : base(defaultPrice, finalPrice)
    {
        MenuItem = menuItem;
    }
}