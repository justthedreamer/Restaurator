using Core.Model.FinancesModel;

namespace Application.DTO;

public class MenuItemReceiptRowDto : ReceiptRowDto
{
    public required MenuItemDto MenuItemDto { get; init; }
}