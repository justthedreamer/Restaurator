using Core.Exceptions.Order;
using Core.Model.FinancesModel;
using Core.Model.MenuModel;
using Core.Model.PromoCodeModel;
using Core.Model.ServicesModel;
using Core.Utilities;
using Core.ValueObject.Finances;
using Core.ValueObject.Order;
using Core.ValueObject.Payment;
using Core.ValueObject.Restaurant;

namespace Core.Model.OrderModel;

/// <summary>
/// Represents restaurant order.
/// </summary>
public abstract class Order : ISoftDelete
{
    public OrderId OrderId { get; private set; }
    public RestaurantId RestaurantId { get; private set; }
    public OrderNumber OrderNumber { get; private set; }
    public OrderType OrderType { get; protected set; }
    public OrderState OrderState { get; protected set; }
    public OrderCreateDate CreatedAt { get; protected set; }
    public IReadOnlyList<MenuItem> MenuItems { get; protected set; } = new List<MenuItem>();
    public IReadOnlyList<Service> Services { get; protected set; } = new List<Service>();
    public PromoCode? PromoCode { get; private set; }
    public OrderMessage? OrderMessage { get; protected set; }
    public Receipt? Receipt { get; protected set; }
    public bool IsDeleted { get; set; } = false;

    /// <summary>
    /// Change order state
    /// </summary>
    /// <param name="orderState">New order state</param>
    internal void ChangeOrderState(OrderState orderState) => OrderState = orderState;

    /// <summary>
    /// Add menu item
    /// </summary>
    /// <param name="menuItem">New menu item</param>
    public void AddMenuItem(MenuItem menuItem) => MenuItems = MenuItems.AddItem(menuItem);

    /// <summary>
    /// Remove menu item
    /// </summary>
    /// <param name="menuItem">Menu item to remove</param>
    public void RemoveMenuItem(MenuItem menuItem) => MenuItems = MenuItems.RemoveItem(menuItem);

    /// <summary>
    /// Add service
    /// </summary>
    /// <param name="service">New service</param>
    public void AddService(Service service) => Services = Services.AddItem(service);

    /// <summary>
    /// Remove service
    /// </summary>
    /// <param name="service">Service to remove</param>
    public void RemoveService(Service service) => Services = Services.RemoveItem(service);

    /// <summary>
    /// Add promotional code
    /// </summary>
    /// <param name="promoCode">Promotional code</param>
    public void AddOrderPromoCode(PromoCode promoCode) => PromoCode = promoCode;

    /// <summary>
    /// Checkout the order
    /// </summary>
    /// <param name="receiptId"></param>
    /// <param name="receiptIssueDate"></param>
    /// <param name="paymentMethod"></param>
    public void Checkout(ReceiptId receiptId, DateTime receiptIssueDate, PaymentMethod paymentMethod)
    {
        if (PromoCode is not null)
        {
            var menuItems = MenuItems.Select(menuItem =>
                    new MenuItemReceiptRow(menuItem, menuItem.RetailPrice, PromoCode.CalculateFinalPrice(menuItem)))
                .ToList().AsReadOnly();

            var services = Services.Select(service =>
                    new ServiceReceiptRow(service, service.ServicePrice, PromoCode.CalculateFinalPrice(service)))
                .ToList()
                .AsReadOnly();

            // Set receipt
            Receipt = new Receipt(receiptId, receiptIssueDate, menuItems, services, paymentMethod);
        }
        else
        {
            var menuItems = MenuItems.Select(menuItem =>
                new MenuItemReceiptRow(menuItem, menuItem.RetailPrice, menuItem.RetailPrice)).ToList().AsReadOnly();

            var services = Services.Select(service =>
                new ServiceReceiptRow(service, service.ServicePrice, service.ServicePrice)).ToList().AsReadOnly();


            // Set receipt
            Receipt = new Receipt(receiptId, receiptIssueDate, menuItems, services, paymentMethod);
        }
    }

    /// <summary>
    /// Mark the order as complete.
    /// </summary>
    protected abstract void MarkOrderAsComplete();

    /// <summary>
    /// Settle the order.
    /// </summary>
    /// <param name="orderMessage"></param>
    public void SettleTheOrder(OrderMessage? orderMessage = null)
    {
        if (Receipt is null)
            throw new MissingOrderCheckoutException();

        if (orderMessage is not null)
            OrderMessage = orderMessage;

        Receipt.Pay();

        MarkOrderAsComplete();
    }

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
    protected Order()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="orderId">Order ID</param>
    /// <param name="orderState">Order state</param>
    /// <param name="createDate">Order deadline</param>
    protected Order(OrderId orderId, OrderState orderState, OrderCreateDate createDate)
    {
        OrderId = orderId;
        OrderState = orderState;
        CreatedAt = createDate;
    }
}