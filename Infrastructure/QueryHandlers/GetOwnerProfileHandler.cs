using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;
using Infrastructure.DAL;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetOwnerProfileHandler(RestauratorDbContext dbContext)
    : IQueryHandler<GetOwnerProfileQuery, OwnerProfileDto>
{
    public async Task<OwnerProfileDto> HandleAsync(GetOwnerProfileQuery query)
    {
        var ownerId = new UserId(query.OwnerId);

        var owner = await dbContext.Owners
            .AsNoTracking()
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Employees)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Menu)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Schedules)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Services)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Tables)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Orders)
            .ThenInclude(order => order.MenuItems).Include(owner => owner.Restaurants)
            .ThenInclude(restaurant => restaurant.Orders).ThenInclude(order => order.Services)
            .Include(owner => owner.Restaurants).ThenInclude(restaurant => restaurant.Orders)
            .ThenInclude(order => order.PromoCode).Include(owner => owner.Restaurants)
            .ThenInclude(restaurant => restaurant.Reservations).ThenInclude(reservation => reservation.Table)
            .SingleOrDefaultAsync(x => x.UserId == ownerId);

        if (owner is null)
            throw new UserNotFoundException();

        var ownerDto = new OwnerDto(owner.UserId, owner.FirstName, owner.LastName, owner.Credentials.Email);

        var restaurants = owner.Restaurants.Select(x => new RestaurantProfileDto()
        {
            Id = x.RestaurantId,
            Address = new AddressDto
            {
                City = x.Address.City.Value,
                Street = x.Address.Street.Value,
                HouseNumber = x.Address.HouseNumber.Value
            },
            Name = x.RestaurantName,
            ContactNumbers = x.PublicPhoneNumbers.Select(pn => pn.Value),
            ContactEmails = x.PublicEmails.Select(e => e.Value),
        });

        return new OwnerProfileDto(ownerDto, restaurants);
    }
}