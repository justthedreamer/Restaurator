using Core.ValueObject.Price;

namespace Application.DTO;

public abstract class ReceiptRowDto
{
    public required Guid ReceiptRowId { get; init; }
    public required Price DefaultPrice { get; init; }
    public required Price FinalPrice { get; init; }
}