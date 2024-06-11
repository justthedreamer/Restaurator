using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder = Core.Model.OrderModel.RestaurantOrder;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantOrdersHandler(
    RestauratorDbContext dbContext,
    IMapper mapper)
    : IQueryHandler<GetRestaurantOrders, IEnumerable<RestaurantOrderDto>>
{
    public async Task<IEnumerable<RestaurantOrderDto>> HandleAsync(GetRestaurantOrders query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var ordersQuery = dbContext.Orders
            .OfType<RestaurantOrder>()
            .Include(o => o.Services)
            .Include(o => o.MenuItems)
            .Include(o => o.Table)
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
                .LoadAsync();

            await dbContext.Entry(receipt!)
                .Collection(r => r.MenuItemReceiptRows)
                .LoadAsync();
        }

        return orders.Select(mapper.Map<RestaurantOrder, RestaurantOrderDto>);
    }
}