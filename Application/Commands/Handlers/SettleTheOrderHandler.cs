using Application.Commands.Abstraction;
using Core.Exceptions.Restaurant;
using Core.Repositories;
using Core.ValueObject.Order;

namespace Application.Commands.Handlers;

internal sealed class SettleTheOrderHandler(IOrderRepository repository) : ICommandHandler<SettleTheOrder>
{
    public async Task HandleAsync(SettleTheOrder command)
    {
        var orderId = new OrderId(command.OrderId);
        var order = await repository.GetOrderAsync(orderId);

        if (order is null)
        {
            throw new OrderNotFoundException();
        }

        var orderMessage = command.OrderMessage is null ? null : new OrderMessage(command.OrderMessage);

        order.SettleTheOrder(orderMessage);
        await repository.UpdateOrderAsync(order);
    }
}