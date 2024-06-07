using Application.DTO.User;
using Core.Model.AddressModel;
using Core.Model.MenuModel;
using Core.Model.RestaurantModel;
using Core.Model.ScheduleModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;

namespace Application.DTO;

public sealed class RestaurantProfileDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required AddressDto Address { get; init; }
    public required IEnumerable<string> ContactNumbers { get; init; }
    public required IEnumerable<string> ContactEmails { get; init; }
}