using Core.Model.FinancesModel;

namespace Application.DTO;

public class MenuItemReceiptRowDto : ReceiptRowDto
{
    public Guid MenuItemId { get; set; }
    public required string MenuItemName { get; set; }
}