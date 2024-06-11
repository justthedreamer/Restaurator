using Application.Commands.Abstraction;
using Core.Exceptions.Restaurant;
using Core.Repositories;
using Core.ValueObject.Finances;
using Core.ValueObject.Order;
using Core.ValueObject.Payment;

namespace Application.Commands.Handlers;

internal sealed class CheckoutTheOrderHandler(IOrderRepository repository) : ICommandHandler<CheckoutTheOrder>
{
    public async Task HandleAsync(CheckoutTheOrder command)
    {
        var orderId = new OrderId(command.OrderId);
        var order = await repository.GetOrderAsync(orderId);

        if (order is null)
        {
            throw new OrderNotFoundException();
        }

        var receiptId = new ReceiptId(Guid.NewGuid());
        var date = DateTime.Now;
        var paymentMethod = new PaymentMethod(command.PaymentMethod.ToUpper());
        order.Checkout(receiptId, date, paymentMethod);
        
        await repository.UpdateOrderAsync(order);
    }
}