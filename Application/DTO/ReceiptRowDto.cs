using Core.ValueObject.Price;

namespace Application.DTO;

public abstract class ReceiptRowDto
{
    public required Guid ReceiptRowId { get; init; }
    public required decimal DefaultPrice { get; init; }
    public required decimal FinalPrice { get; init; }
}