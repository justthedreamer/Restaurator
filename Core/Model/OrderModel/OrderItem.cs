using Core.Model.FinancesModel;
using Core.Model.MenuModel;
using Core.Model.PromoCodeModel;

namespace Core.Model.OrderModel;

/// <summary>
/// Represent Order item
/// </summary>
public sealed class OrderItem
{
    public Guid OrderItemId { get; private set; }
    public MenuItem MenuItem { get; internal set; }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="orderItemId">Order item ID</param>
    /// <param name="menuItem">Menu item</param>
    public OrderItem(Guid orderItemId, MenuItem menuItem)
    {
        OrderItemId = orderItemId;
        MenuItem = menuItem;
    }
}