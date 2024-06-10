using Core.Exceptions.Order;
using Core.Model.AddressModel;
using Core.Model.FinancesModel;
using Core.Model.MenuModel;
using Core.Model.ServicesModel;
using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Finances;
using Core.ValueObject.Order;
using Core.ValueObject.Payment;
using Core.ValueObject.Staff.Employee;

namespace Core.Model.OrderModel;

/// <summary>
/// Represents order to delivery.
/// </summary>
public class DeliveryOrder : Order
{
    public FirstName CustomerFirstName { get; private set; }
    public LastName CustomerLastName { get; private set; }
    public Address CustomerAddress { get; private set; }
    public PhoneNumber CustomerPhoneNumber { get; private set; }
    public Employee? Courier { get; private set; }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected DeliveryOrder() : base()
    {
    }

    /// <summary>
    /// Get order to delivery
    /// </summary>
    /// <param name="courier">Courier</param>
    public void GetToDelivery(Employee courier)
    {
        if (OrderState != OrderState.Ready)
        {
            throw new InvalidOrderStateException(OrderState, "Order have to be in state Ready to process delivery.");
        }

        OrderState = OrderState.InDelivery;
        Courier = courier;
    }

    /// <summary>
    /// Set order state to deliver.
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    protected override void MarkOrderAsComplete()
    {
        OrderState = OrderState.Delivered;
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="orderId">Order ID</param>
    /// <param name="orderState">Order State</param>
    /// <param name="createDate">Order deadline</param>
    /// <param name="customerFirstName">Customer First Name</param>
    /// <param name="customerLastName">Customer Last Name</param>
    /// <param name="customerAddress">Customer Address</param>
    /// <param name="customerPhoneNumber">Customer Phone number</param>
    /// <param name="courier">Delivery man (Employee)</param>
    public DeliveryOrder(OrderId orderId, OrderState orderState, OrderCreateDate createDate,
        FirstName customerFirstName, LastName customerLastName, Address customerAddress,
        PhoneNumber customerPhoneNumber, Employee? courier) : base(orderId, orderState, createDate)
    {
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        CustomerAddress = customerAddress;
        CustomerPhoneNumber = customerPhoneNumber;
        Courier = courier;
        OrderType = OrderType.DeliveryOrder;
    }
}