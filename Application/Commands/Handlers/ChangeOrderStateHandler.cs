using Application.Commands.Abstraction;
using Core.Exceptions.Restaurant;
using Core.Repositories;
using Core.Services.Abstraction;
using Core.ValueObject.Order;

namespace Application.Commands.Handlers;

internal sealed class ChangeOrderStateHandler(IOrderRepository orderRepository, IOrderService orderService)
    : ICommandHandler<ChangeOrderState>
{
    public async Task HandleAsync(ChangeOrderState command)
    {
        var orderId = new OrderId(command.OrderId);
        var order = await orderRepository.GetOrderAsync(orderId);

        if (order is null)
        {
            throw new OrderNotFoundException();
        }

        var orderState = new OrderState(command.OrderState.ToUpper());
        orderService.ChangeOrderState(order,orderState);
        await orderRepository.UpdateOrderAsync(order);
    }
}