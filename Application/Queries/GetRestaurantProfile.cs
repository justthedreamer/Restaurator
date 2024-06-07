using System.Reflection.Metadata.Ecma335;
using Application.DTO;
using Application.Queries.Abstraction;
using Core.Model.AddressModel;
using Core.ValueObject.Common;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantProfile(Guid restaurantId) : IQuery<RestaurantProfileDto>{}
