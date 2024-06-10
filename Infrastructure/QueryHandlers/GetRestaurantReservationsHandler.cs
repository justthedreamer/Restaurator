using Application.DTO;
using Application.Exceptions;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.ReservationModel;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantReservationsHandler(RestauratorDbContext dbContext,IMapper mapper) : IQueryHandler<GetRestaurantReservations,IEnumerable<ReservationDto>>
{
    public async Task<IEnumerable<ReservationDto>> HandleAsync(GetRestaurantReservations query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var restaurant = await dbContext.Restaurants
            .AsNoTracking()
            .Include(r => r.Reservations)
            .ThenInclude(r => r.Table)
            .SingleOrDefaultAsync(r => r.RestaurantId == restaurantId);

        if (restaurant is null)
        {
            throw new RestaurantNotFoundException();
        }

        var reservations = restaurant.Reservations.ToList();
        
        if (query.From is not null)
        {
            reservations = reservations.Where(r => r.ReservationDate.Value >= query.From).ToList();
        }

        if (query.To is not null)
        {
            reservations = reservations.Where(r => r.ReservationDate <= query.To).ToList();
        }

        var dtos = reservations.Select(mapper.Map<Reservation, ReservationDto>);
        return dtos;
    }
}