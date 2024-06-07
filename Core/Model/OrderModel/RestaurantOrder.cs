using Core.Exceptions.Order;
using Core.Model.FinancesModel;
using Core.Model.MenuModel;
using Core.Model.RestaurantModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Finances;
using Core.ValueObject.Order;

namespace Core.Model.OrderModel;

/// <summary>
/// Represent order placed in restaurant.
/// </summary>
public class RestaurantOrder : Order
{
    public Table Table { get; private set; }

    /// <summary>
    /// Set order state to complete.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    protected override void MarkOrderAsComplete()
    {
        OrderState = OrderState.Completed;
    }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private RestaurantOrder() : base()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="orderId">Order ID</param>
    /// <param name="orderState">Order state</param>
    /// <param name="createDate">Order deadline</param>
    /// <param name="table">Customers table</param>
    /// <param name="menuItems">Dish list</param>
    public RestaurantOrder(OrderId orderId, OrderState orderState, OrderCreateDate createDate, List<MenuItem> menuItems,List<Service> services,
        Table? table) : base(orderId, orderState, createDate, menuItems,services)
    {
        Table = table;
        OrderType = OrderType.RestaurantOrder;
    }
}