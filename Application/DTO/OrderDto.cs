namespace Application.DTO;

public abstract class OrderDto 
{
    public required Guid Id { get; init; }
    public required  int OrderNumber { get; init; }
    public required  string OrderState { get; init; }
    public required  DateTime CreatedAt { get; init; }
    public required  IEnumerable<MenuItemDto> MenuItems { get; init; }
    public required  IEnumerable<ServiceDto> Services { get; init; }
    public PromoCodeDto? PromoCode { get; init; }
    public string? OrderMessage { get; init; }
    public ReceiptDto? Receipt { get; init; }
    public IEnumerable<string>? AvailableStates { get; init; }
}