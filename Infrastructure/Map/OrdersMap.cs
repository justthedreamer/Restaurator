using Application.DTO;
using AutoMapper;
using Core.Model.OrderModel;
using Core.Model.ServicesModel;

namespace Infrastructure.Map;

internal partial class MainMapProfile
{
    partial void ApplyOrdersMapping()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(o => o.OrderId.Value))
            .ForMember(dto => dto.OrderNumber, ex => ex.MapFrom(o => o.OrderNumber.Value))
            .ForMember(dto => dto.OrderState, ex => ex.MapFrom(o => o.OrderState.Value))
            .ForMember(dto => dto.CreatedAt, ex => ex.MapFrom(o => o.CreatedAt.Value))
            .ForMember(dto => dto.OrderMessage,
                ex => ex.MapFrom(o => o.OrderMessage == null ? null : o.OrderMessage.Value))
            .ForMember(dto => dto.Receipt, ex => ex.MapFrom(o => o.Receipt == null
                ? null
                : new ReceiptDto()
                {
                    ReceiptId = o.Receipt.ReceiptId.Value,
                    PaymentMethod = o.Receipt.PaymentMethod.Value,
                    PaymentState = o.Receipt.PaymentState.Value,
                    DateOfIssue = o.Receipt.DateOfIssue,
                    Services = o.Receipt.ServiceReceiptRows.Select(row => new ServiceReceiptRowDto()
                    {
                        ReceiptRowId = row.ReceiptRowId,
                        ServiceId = row.Service.ServiceId,
                        ServiceName = row.Service.ServiceName.Value,
                        DefaultPrice = row.DefaultPrice.Value,
                        FinalPrice = row.FinalPrice.Value,
                    }),
                    MenuItems = o.Receipt.MenuItemReceiptRows.Select(row => new MenuItemReceiptRowDto()
                    {
                        ReceiptRowId = row.ReceiptRowId,
                        MenuItemId = row.MenuItem.MenuItemId.Value,
                        MenuItemName = row.MenuItem.MenuItemName.Value,
                        DefaultPrice = row.DefaultPrice.Value,
                        FinalPrice = row.FinalPrice.Value
                    }),
                    DefaultPrice = o.Receipt.DefaultPrice.Value,
                    FinalPrice = o.Receipt.FinalPrice.Value,
                }))
            .ForMember(dto => dto.MenuItems, ex => ex.MapFrom(o => o.MenuItems.Select(mi => new MenuItemDto()
            {
                Id = mi.MenuItemId.Value,
                Category = mi.Category.Value,
                Ingredients = mi.Ingredients.Select(i => i.IngredientName.Value),
                Name = mi.MenuItemName.Value,
                Price = mi.RetailPrice.Value,
                Description = mi.Description == null ? null : mi.Description.Value,
                PrepareTime = mi.PrepareTime == null ? null : mi.PrepareTime.Value
            })))
            .ForMember(dto => dto.Services, ex => ex.MapFrom(o => o.Services.Select(s => new ServiceDto
            {
                Id = s.ServiceId.Value,
                Name = s.ServiceName.Value,
                Price = s.ServicePrice.Value
            })));

        CreateMap<RestaurantOrder, RestaurantOrderDto>()
            .IncludeBase<Order, OrderDto>()
            .ForMember(dto => dto.TableSign, ex => ex.MapFrom(ro => ro.Table.TableSign.Value));

        CreateMap<TakeAwayOrder, TakeAwayOrderDto>()
            .IncludeBase<Order, OrderDto>()
            .ForMember(dto => dto.CustomerFirstName, ex => ex.MapFrom(o => o.CustomerFirstName.Value))
            .ForMember(dto => dto.CustomerLastName, ex => ex.MapFrom(o => o.CustomerLastName.Value));

        CreateMap<DeliveryOrder, DeliveryOrderDto>()
            .IncludeBase<Order, OrderDto>()
            .ForMember(dto => dto.CustomerFirstName, ex => ex.MapFrom(o => o.CustomerFirstName.Value))
            .ForMember(dto => dto.CustomerLastName, ex => ex.MapFrom(o => o.CustomerLastName.Value))
            .ForMember(dto => dto.CustomerPhoneNumber, ex => ex.MapFrom(o => o.CustomerPhoneNumber.Value))
            .ForMember(dto => dto.CustomerAddress, ex => ex.MapFrom(o => new AddressDto
            {
                City = o.CustomerAddress.City.Value,
                Street = o.CustomerAddress.Street.Value,
                HouseNumber = o.CustomerAddress.HouseNumber.Value,
            }))
            .ForMember(dto => dto.CourierPhoneNumber,
                ex => ex.MapFrom(o => o.Courier == null ? null : o.Courier.PhoneNumber.Value));
    }
}