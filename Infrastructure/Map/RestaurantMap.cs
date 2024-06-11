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
            .ForMember(dto => dto.Id, ex => ex.MapFrom(r => r.RestaurantId.Value))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(r => r.RestaurantName.Value))
            .ForMember(dto => dto.ContactEmails, ex => ex.MapFrom(r => r.PublicEmails.Select(e => e.Value)))
            .ForMember(dto => dto.ContactNumbers, ex => ex.MapFrom(r => r.PublicPhoneNumbers.Select(e => e.Value)))
            .ForMember(dto => dto.Address,
                ex => ex.MapFrom(r => new AddressDto
                {
                    City = r.Address.City.Value,
                    Street = r.Address.Street.Value,
                    HouseNumber = r.Address.HouseNumber.Value
                }));

        CreateMap<Service, ServiceDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(s => s.ServiceId.Value))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(s => s.ServiceName.Value))
            .ForMember(dto => dto.Price, ex => ex.MapFrom(s => s.ServicePrice.Value));
        
        CreateMap<MenuItem, MenuItemDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(mi => mi.MenuItemId.Value))
            .ForMember(dto => dto.Name, ex => ex.MapFrom(mi => mi.MenuItemName.Value))
            .ForMember(dto => dto.Category, ex => ex.MapFrom(mi => mi.Category.Value))
            .ForMember(dto => dto.Price, ex => ex.MapFrom(mi => mi.RetailPrice.Value))
            .ForMember(dto => dto.Description, ex => ex.MapFrom(mi => mi.Description == null ? null : mi.Description.Value))
            .ForMember(dto => dto.PrepareTime, ex => ex.MapFrom(mi => mi.PrepareTime == null ? null : mi.PrepareTime.Value))
            .ForMember(dto => dto.Ingredients, ex => ex.MapFrom(mi => mi.Ingredients.Select(i => i.IngredientName.Value)));

        CreateMap<Reservation, ReservationDto>()
            .ForMember(dto => dto.Id, ex => ex.MapFrom(r => r.ReservationId))
            .ForMember(dto => dto.TableSign, ex => ex.MapFrom(r => r.Table.TableSign));

        CreateMap<Table, TableDto>()
            .ForMember(dto => dto.TableId, ex => ex.MapFrom(t => t.TableId.Value))
            .ForMember(dto => dto.TableSign, ex => ex.MapFrom(t => t.TableSign.Value))
            .ForMember(dto => dto.SeatsCount, ex => ex.MapFrom(t => t.SeatsCount.Value));
    }
}