using Core.Model.ServicesModel;
using Core.ValueObject.Price;

namespace Core.Model.FinancesModel;

public class ServiceReceiptRow : ReceiptRow
{
    public Service Service { get; private set; } = null!;

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private ServiceReceiptRow() : base()
    {
    }

    /// <summary>
    /// General constructor.
    /// </summary>
    /// <param name="service">Service item.</param>
    /// <param name="defaultPrice">Menu item default price.</param>
    /// <param name="finalPrice">Final price after applying promotional code.</param>
    public ServiceReceiptRow(Service service, Price defaultPrice, Price finalPrice) : base(defaultPrice, finalPrice)
    {
        Service = service;
    }
}