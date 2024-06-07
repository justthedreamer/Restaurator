using Core.ValueObject.Order;

namespace Application.DTO;

public abstract class OrderDto 
{
    public required OrderId Id { get; init; }
    public required  OrderNumber OrderNumber { get; init; }
    public required  OrderState OrderState { get; init; }
    public required  OrderCreateDate CreatedAt { get; init; }
    public required  IEnumerable<MenuItemDto> MenuItems { get; init; }
    public required  IEnumerable<ServiceDto> Services { get; init; }
    public PromoCodeDto? PromoCode { get; init; }
    public OrderMessage? OrderMessage { get; init; }
    public ReceiptDto? Receipt { get; init; }
    public IEnumerable<string>? AvailableStates { get; init; }
}