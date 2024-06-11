using Core.Model.OrderModel;
using Core.Repositories;
using Core.ValueObject.Order;
using Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class OrderRepository(RestauratorDbContext dbContext) : IOrderRepository
{
    public async Task<Order?> GetOrderAsync(OrderId orderId)
    {
        var order = await dbContext.Orders
            .Include(o => o.Services)
            .Include(o => o.MenuItems).ThenInclude(m => m.Ingredients)
            .SingleOrDefaultAsync(o => o.OrderId == orderId);
        return order;
    }

    public async Task UpdateOrderAsync(Order order)
    {
        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateRestaurantOrderAsync(RestaurantOrder order)
    {
        dbContext.RestaurantOrders.Update(order);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateTakeAwayOrderAsync(TakeAwayOrder order)
    {
        dbContext.TakeAwayOrders.Update(order);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateDeliveryOrderAsync(DeliveryOrder order)
    {
        dbContext.DeliveryOrders.Update(order);
        await dbContext.SaveChangesAsync();
    }
}