using Core.ValueObject.Finances;
using Core.ValueObject.Payment;

namespace Application.DTO;

public class ReceiptDto
{
    public required Guid ReceiptId { get; init; }
    public required DateTime DateOfIssue { get; init; }
    public required IEnumerable<MenuItemReceiptRowDto> MenuItems { get; init; }
    public required IEnumerable<ServiceReceiptRowDto> Services { get; init; }
    public required string PaymentMethod { get; init; }
    public required string PaymentState { get; init; }
}