using Core.ValueObject.Finances;
using Core.ValueObject.Payment;
using Core.ValueObject.Price;

namespace Core.Model.FinancesModel;

/// <summary>
/// Represents receipt
/// </summary>
public class Receipt
{
    public ReceiptId ReceiptId { get; private set; }
    public DateTime DateOfIssue { get; private set; }
    public IReadOnlyList<MenuItemReceiptRow> MenuItemReceiptRows { get; }
    public IReadOnlyList<ServiceReceiptRow> ServiceReceiptRows { get; }
    public PaymentMethod PaymentMethod { get; private set; }
    public PaymentState PaymentState { get; private set; }
    public Price DefaultPrice => GetDefaultPrice();
    public Price FinalPrice => GetFinalPrice();

    /// <summary>
    /// Calculate default price
    /// </summary>
    /// <returns>Default price</returns>
    private Price GetDefaultPrice()
    {
        var menuItems = MenuItemReceiptRows.Sum(x => x.DefaultPrice.Value);
        var services = MenuItemReceiptRows.Sum(x => x.DefaultPrice.Value);
        return menuItems + services;
    }
    
    /// <summary>
    /// Calculate final price
    /// </summary>
    /// <returns>Final price</returns>
    private Price GetFinalPrice()
    {
        var menuItems = MenuItemReceiptRows.Sum(x => x.FinalPrice.Value);
        var services = MenuItemReceiptRows.Sum(x => x.FinalPrice.Value);
        return menuItems + services;
    }
    
    /// <summary>
    /// Update payment method
    /// </summary>
    /// <param name="paymentMethod">New payment method</param>
    internal void UpdatePaymentMethod(PaymentMethod paymentMethod) => PaymentMethod = paymentMethod;

    /// <summary>
    /// Update payment method
    /// </summary>
    /// <param name="paymentState">New payment method</param>
    internal void UpdatePaymentState(PaymentState paymentState) => PaymentState = paymentState;

    /// <summary>
    /// Paid the receipt.
    /// </summary>
    internal void Pay()
    {
        PaymentState = PaymentState.Payed;
    }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Receipt()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="receiptId">Receipt ID</param>
    /// <param name="dateOfIssue">Date of issue</param>
    /// <param name="serviceReceiptRows">Services rows</param>
    /// <param name="menuItemReceiptRows">Menu items rows</param>
    /// <param name="paymentMethod">Payment method</param>
    public Receipt(ReceiptId receiptId, DateTime dateOfIssue,IReadOnlyList<MenuItemReceiptRow> menuItemReceiptRows,IReadOnlyList<ServiceReceiptRow> serviceReceiptRows,PaymentMethod paymentMethod)
    {
        ReceiptId = receiptId;
        DateOfIssue = dateOfIssue;
        MenuItemReceiptRows = menuItemReceiptRows;
        ServiceReceiptRows = serviceReceiptRows;
        PaymentMethod = paymentMethod;
        PaymentState = ValueObject.Payment.PaymentState.NotPayed;
    }
    
}