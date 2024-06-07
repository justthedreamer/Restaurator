using Core.ValueObject.Finances;
using Core.ValueObject.Payment;

namespace Application.DTO;

public class ReceiptDto
{
    public required ReceiptId ReceiptId { get; init; }
    public required DateTime DateOfIssue { get; init; }
    public required IEnumerator<MenuItemReceiptRowDto> MenuItems { get; init; }
    public required IEnumerator<ServiceReceiptRowDto> Services { get; init; }
    public PaymentMethod? PaymentMethod { get; init; }
    public PaymentState? PaymentState { get; init; }
}