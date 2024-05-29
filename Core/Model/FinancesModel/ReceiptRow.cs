using System.Reflection.Metadata.Ecma335;
using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.PromoCodeModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Price;

namespace Core.Model.FinancesModel;

/// <summary>
/// Represents Receipt row
/// </summary>
public abstract class ReceiptRow
{
    public Guid ReceiptRowId { get; set; }
    public Price DefaultPrice { get; protected set; }
    public Price FinalPrice { get; protected set; }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected ReceiptRow()
    {
    }

    /// <summary>
    /// General protected constructor
    /// </summary>
    /// <param name="defaultPrice">Item default price.</param>
    /// <param name="finalPrice">Item price after applying promotional code.</param>
    protected ReceiptRow(Price defaultPrice, Price finalPrice)
    {
        DefaultPrice = defaultPrice;
        FinalPrice = finalPrice;
    }
}