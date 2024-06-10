using Application.DTO;
using AutoMapper;
using Core.Model.MenuModel;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Model.ServicesModel;

namespace Infrastructure.Map;

internal partial class MainMapProfile
{
    partial void ApplyRestaurantMapping()
    {
        CreateMap<Restaurant, RestaurantProfileDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(r => r.RestaurantId))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(r => r.RestaurantName.Value))
            .ForMember(dto => dto.ContactEmails, ex => ex.MapFrom(r => r.PublicEmails.Select(e => e.Value)))
            .ForMember(dto => dto.ContactNumbers, ex => ex.MapFrom(r => r.PublicPhoneNumbers.Select(e => e.Value)))
            .ForMember(dto => dto.Address,
                ex => ex.MapFrom(r => new AddressDto(r.Address.City, r.Address.Street, r.Address.HouseNumber)));

        CreateMap<Service, ServiceDto>()
            .ForMember(dto => dto.Price,
                ex => ex.MapFrom(s => s.ServicePrice))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(s => s.ServiceName));

        CreateMap<MenuItem, MenuItemDto>()
            .ForMember(dto => dto.Price, ex => ex.MapFrom(mi => mi.RetailPrice))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(mi => mi.MenuItemName))
            .ForMember(dto => dto.Id, ex => ex.MapFrom(mi => mi.MenuItemId))
            .ForMember(dto => dto.Ingredients,
                ex => ex.MapFrom(mi => mi.Ingredients.Select(i => i.IngredientName.Value)));

        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(r => r.ReservationId))
            .ForMember(dto => dto.TableSign, ex => ex.MapFrom(r => r.Table.TableSign));

        CreateMap<Table, TableDto>()
            .ForMember(dto => dto.TableId, ex => ex.MapFrom(t => t.TableId.Value))
            .ForMember(dto => dto.TableSign, ex => ex.MapFrom(t => t.TableSign.Value))
            .ForMember(dto => dto.SeatsCount, ex => ex.MapFrom(t => t.SeatsCount.Value));
    }
}