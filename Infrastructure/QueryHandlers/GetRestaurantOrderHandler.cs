using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Exceptions.Restaurant;
using Core.Model.OrderModel;
using Core.ValueObject.Order;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantOrderHandler(RestauratorDbContext dbContext,IMapper mapper)
    : IQueryHandler<GetRestaurantOrder, RestaurantOrderDto>
{
    public async Task<RestaurantOrderDto> HandleAsync(GetRestaurantOrder query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        
        var orderId = new OrderId(query.OrderId);
        
        var order = await dbContext.Orders
            .OfType<RestaurantOrder>()
            .Include(o => o.Table)
            .Include(o => o.Services)
            .Include(o => o.MenuItems)
            .Include(o => o.Receipt)
            .Include(o => o.PromoCode)
            .Where(o => o.RestaurantId == restaurantId)
            .SingleOrDefaultAsync(o => o.OrderId == orderId );


        if (order is null)
        {
            throw new OrderNotFoundException();
        }

        if (order.Receipt is not null)
        {
            await dbContext
                .Entry(order.Receipt)
                .Collection(r => r.MenuItemReceiptRows)
                .Query()
                .Include(r => r.MenuItem)
                .LoadAsync();
        }

        return mapper.Map<RestaurantOrder, RestaurantOrderDto>(order);
    }
}