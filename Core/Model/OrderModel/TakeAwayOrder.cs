using Core.Exceptions.Order;
using Core.Model.MenuModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Order;
using Core.ValueObject.Staff.Employee;

namespace Core.Model.OrderModel;

public class TakeAwayOrder : Order
{
    public FirstName CustomerFirstName { get; private set; }
    public LastName CustomerLastName { get; private set; }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    public TakeAwayOrder() : base()
    {
    }

    /// <summary>
    /// Set order state to complete.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    protected override void MarkOrderAsComplete()
    {
        OrderState = OrderState.Completed;
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="orderId">ID</param>
    /// <param name="orderState">Order state</param>
    /// <param name="createDate">Create date</param>
    /// <param name="customerFirstName">Customer First Name</param>
    /// <param name="customerLastName">Customer Last Name</param>
    public TakeAwayOrder(OrderId orderId, OrderState orderState, OrderCreateDate createDate,
        FirstName customerFirstName, LastName customerLastName) : base(orderId, orderState,
        createDate)
    {
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        OrderType = OrderType.TakeAwayOrder;
    }
}