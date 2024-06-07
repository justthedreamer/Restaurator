using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using AutoMapper;
using Core.Exceptions.Order;
using Core.Model.OrderModel;
using Core.Services.Abstraction;
using Core.ValueObject.Order;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.QueryHandlers;

internal sealed class GetRestaurantOrdersHandler(
    RestauratorDbContext dbContext,
    IMapper mapper,
    IOrderService orderService)
    : IQueryHandler<GetRestaurantOrders, IEnumerable<OrderDto>>
{
    public async Task<IEnumerable<OrderDto>> HandleAsync(GetRestaurantOrders query)
    {
        switch (query.OrderType)
        {
            case OrderType.DeliveryOrder:
            {
                var dtos = await HandlerDeliveryOrdersAsync(query);
                return dtos;
            }
            case OrderType.RestaurantOrder:
            {
                var dtos = await HandlerRestaurantOrdersAsync(query);
                return dtos;
            }
            case OrderType.TakeAwayOrder:
            {
                var dtos = await HandleTakeAwayOrdersAsync(query);
                return dtos;
            }
            case null:
            {
                var result = new List<OrderDto>();
                
                var restaurantOrders = await HandleTakeAwayOrdersAsync(query);
                var takeAwayOrders = await HandleTakeAwayOrdersAsync(query);
                var deliveryOrders = await HandlerDeliveryOrdersAsync(query);
                
                result.AddRange(restaurantOrders);
                result.AddRange(takeAwayOrders);
                result.AddRange(deliveryOrders);

                return result.AsEnumerable();
            }
            default:
            {
                throw new InvalidOrderTypeException(query.OrderType);
            }
        }
    }

    private async Task<IEnumerable<TakeAwayOrderDto>> HandleTakeAwayOrdersAsync(GetRestaurantOrders query)
    {
        var orders = await dbContext.Orders
            .AsNoTracking()
            .OfType<TakeAwayOrder>()
            .Include(r => r.Services)
            .Include(r => r.MenuItems)
            .Include(r => r.PromoCode)
            .Include(r => r.Receipt)
            .ToListAsync();

        ApplyRangeFiltering(orders, query.From, query.To);

        var dtos = orders.Select(mapper.Map<TakeAwayOrder, TakeAwayOrderDto>);

        return dtos;
    }

    private async Task<IEnumerable<RestaurantOrderDto>> HandlerRestaurantOrdersAsync(GetRestaurantOrders query)
    {
        var orders = await dbContext.Orders
            .AsNoTracking()
            .OfType<RestaurantOrder>()
            .Include(r => r.Services)
            .Include(r => r.MenuItems)
            .Include(r => r.PromoCode)
            .Include(r => r.Receipt)
            .Include(r => r.Table)
            .ToListAsync();

        ApplyRangeFiltering(orders, query.From, query.To);

        var dtos = orders.Select(mapper.Map<RestaurantOrder, RestaurantOrderDto>);

        return dtos;
    }

    private async Task<IEnumerable<DeliveryOrderDto>> HandlerDeliveryOrdersAsync(GetRestaurantOrders query)
    {
        var orders = await dbContext.Orders
            .AsNoTracking()
            .OfType<DeliveryOrder>()
            .Include(r => r.Services)
            .Include(r => r.MenuItems)
            .Include(r => r.PromoCode)
            .Include(r => r.Receipt)
            .Include(r => r.Courier)
            .ToListAsync();

        ApplyRangeFiltering(orders, query.From, query.To);

        var dtos = orders.Select(mapper.Map<DeliveryOrder, DeliveryOrderDto>);
        return dtos;
    }

    private static void ApplyRangeFiltering(IEnumerable<Order> orders, DateTime? from, DateTime? to)
    {
        if (from is not null)
        {
            orders = orders.Where(o => o.CreatedAt.Value >= from).ToList();
        }

        if (to is not null)
        {
            orders = orders.Where(o => o.CreatedAt.Value <= to).ToList();
        }
    }
}