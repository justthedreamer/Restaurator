using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Model.OrderModel;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetTakeAwayOrdersHandler(RestauratorDbContext dbContext,IMapper mapper) : IQueryHandler<GetTakeAwayOrders,IEnumerable<TakeAwayOrderDto>>
{
    public async Task<IEnumerable<TakeAwayOrderDto>> HandleAsync(GetTakeAwayOrders query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var ordersQuery = dbContext.Orders
            .OfType<TakeAwayOrder>()
            .Include(o => o.Services)
            .Include(o => o.MenuItems)
            .Include(o => o.Receipt)
            .Include(o => o.PromoCode)
            .Where(o => o.RestaurantId == restaurantId);


        if (query.From is not null)
        {
            ordersQuery = ordersQuery.Where(o => o.CreatedAt.Value >= query.From);
        }

        if (query.To is not null)
        {
            ordersQuery = ordersQuery.Where(o => o.CreatedAt.Value <= query.To);
        }

        var orders = await ordersQuery.ToListAsync();

        var receipts = orders.Select(o => o.Receipt).Where(r => r is not null);
        
        foreach (var receipt in receipts)
        {
            await dbContext.Entry(receipt!)
                .Collection(r => r.ServiceReceiptRows)
                .Query()
                .Include(r => r.Service)
                .LoadAsync();

            await dbContext.Entry(receipt!)
                .Collection(r => r.MenuItemReceiptRows)
                .Query()
                .Include(r => r.MenuItem)
                .LoadAsync();
        }

        return orders.Select(mapper.Map<TakeAwayOrder, TakeAwayOrderDto>);
    }
}