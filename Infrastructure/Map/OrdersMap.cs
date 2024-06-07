using Application.DTO;
using AutoMapper;
using Core.Model.OrderModel;
using Core.Model.ServicesModel;

namespace Infrastructure.Map;

internal partial class RestauratorMap
{
    partial void InitializeOrdersMapping()
    {
        CreateMap<RestaurantOrder, RestaurantOrderDto>()
            .ForMember(dto => dto.Id,ex => ex.MapFrom(ro => ro.OrderId))
            .ForMember(dto => dto.MenuItems, ex => ex.MapFrom(ro => ro.MenuItems.Select(mi => new MenuItemDto()
            {
                Id = mi.MenuItemId,
                Category = mi.Category,
                Name = mi.MenuItemName,
                Ingredients = mi.Ingredients.Select(i => i.IngredientName.Value),
                Price = mi.RetailPrice,
                Description = mi.Description,
                PrepareTime = mi.PrepareTime
            })))
            .ForMember(dto => dto.Services,ex => ex.MapFrom(ro => ro.Services.Select(s => new ServiceDto()
            {
                Name = s.ServiceName,
                Price = s.ServicePrice
            })))
            .ForMember(dto => dto.TableSign,ex => ex.MapFrom(ro => ro.Table.TableSign));

        CreateMap<TakeAwayOrder, TakeAwayOrderDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(ro => ro.OrderId))
            .ForMember(dto => dto.MenuItems, ex => ex.MapFrom(ro => ro.MenuItems.Select(mi => new MenuItemDto()
            {
                Id = mi.MenuItemId,
                Category = mi.Category,
                Name = mi.MenuItemName,
                Ingredients = mi.Ingredients.Select(i => i.IngredientName.Value),
                Price = mi.RetailPrice,
                Description = mi.Description,
                PrepareTime = mi.PrepareTime
            })))
            .ForMember(dto => dto.Services, ex => ex.MapFrom(ro => ro.Services.Select(s => new ServiceDto()
            {
                Name = s.ServiceName,
                Price = s.ServicePrice
            })));
        
        CreateMap<DeliveryOrder,DeliveryOrderDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(ro => ro.OrderId))
            .ForMember(dto => dto.MenuItems, ex => ex.MapFrom(ro => ro.MenuItems.Select(mi => new MenuItemDto()
            {
                Id = mi.MenuItemId,
                Category = mi.Category,
                Name = mi.MenuItemName,
                Ingredients = mi.Ingredients.Select(i => i.IngredientName.Value),
                Price = mi.RetailPrice,
                Description = mi.Description,
                PrepareTime = mi.PrepareTime
            })))
            .ForMember(dto => dto.Services, ex => ex.MapFrom(ro => ro.Services.Select(s => new ServiceDto()
            {
                Name = s.ServiceName,
                Price = s.ServicePrice
            })))
            .ForMember(dto => dto.Courier,ex => ex.MapFrom(o => o.Courier == null ? null : new CourierDto(){CourierName = o.Courier.FirstName,PhoneNumber = o.Courier.PhoneNumber}));
    }
}