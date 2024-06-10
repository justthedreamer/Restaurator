using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Services.Abstraction;
using Core.ValueObject.Restaurant;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using RestaurantOrder = Core.Model.OrderModel.RestaurantOrder;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantOrdersHandler(
    RestauratorDbContext dbContext,
    IMapper mapper,
    IOrderService orderService)
    : IQueryHandler<GetRestaurantOrders, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> HandleAsync(GetRestaurantOrders query)
    {
        var restaurantId = new RestaurantId(query.RestaurantId);
        var orders = await dbContext.Orders
            .OfType<RestaurantOrder>()
            .Include(o => o.Services)
            .Include(o => o.MenuItems)
            .Include(o => o.Table)
            .Include(o => o.Receipt).ThenInclude(r => r.ServiceReceiptRows)
            .Include(o => o.Receipt).ThenInclude(r => r.MenuItemReceiptRows)
            .Include(o => o.PromoCode)
            .Where(o => o.RestaurantId == restaurantId)
            .ToListAsync();

        
        if (query.From is not null)
        {
            orders = orders.Where(o => o.CreatedAt.Value >= query.From).ToList();
        }

        if (query.To is not null)
        {
            orders = orders.Where(o => o.CreatedAt.Value <= query.To).ToList();
        }

        return orders.Select(mapper.Map<RestaurantOrder, RestaurantOrderDto>);
    }
}