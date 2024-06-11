using Application.Commands;
using Application.Commands.Abstraction;
using Application.DTO;
using Application.Queries;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("/restaurant/{restaurantId:guid}/orders")]
[ApiController]
public class OrdersController(
    IQueryHandler<GetUserRole, UserRole> getUserRole,
    IQueryHandler<GetRestaurantOrders, IEnumerable<RestaurantOrderDto>> getRestaurantOrders,
    IQueryHandler<GetRestaurantOrder, RestaurantOrderDto> getRestaurantOrder,
    IQueryHandler<GetTakeAwayOrders, IEnumerable<TakeAwayOrderDto>> getTakeAwayOrders,
    IQueryHandler<GetTakeAwayOrder, TakeAwayOrderDto> getTakeAwayOrder,
    IQueryHandler<GetDeliveryOrders, IEnumerable<DeliveryOrderDto>> getDeliveryOrders,
    IQueryHandler<GetDeliveryOrder, DeliveryOrderDto> getDeliveryOrder,
    ICommandHandler<CreateRestaurantOrder> createRestaurantOrder,
    ICommandHandler<ChangeOrderState> changeOrderState,
    ICommandHandler<CreateTakeAwayOrder> createTakeAwayOrder,
    ICommandHandler<CreateDeliveryOrder> createDeliveryOrder,
    ICommandHandler<DeleteOrder> deleteOrder,
    ICommandHandler<CheckoutTheOrder> checkoutTheOrder,
    ICommandHandler<SettleTheOrder> settleTheOrder) : ControllerBase
{
    [HttpGet("restaurant")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<RestaurantOrderDto>>> GetRestaurantOrders(Guid restaurantId,
        [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var orders = await getRestaurantOrders.HandleAsync(new GetRestaurantOrders(restaurantId, from, to));
        return Ok(orders);
    }

    [HttpGet("restaurant/{orderId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<RestaurantOrderDto>> GetRestaurantOrder(Guid restaurantId, Guid orderId)
    {
        var order = await getRestaurantOrder.HandleAsync(new GetRestaurantOrder()
            { RestaurantId = restaurantId, OrderId = orderId });
        return Ok(order);
    }

    [HttpPost("restaurant")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateRestaurantOrder(Guid restaurantId, CreateRestaurantOrder command)
    {
        var orderId = Guid.NewGuid();
        await createRestaurantOrder.HandleAsync(command with { RestaurantId = restaurantId, OrderId = orderId });

        return CreatedAtAction(nameof(GetRestaurantOrder), new { restaurantId = restaurantId, orderId = orderId },
            null);
    }

    [HttpGet("take-away")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<TakeAwayOrderDto>>> GetTakeAwayOrders(Guid restaurantId,
        [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var orders = await getTakeAwayOrders.HandleAsync(new GetTakeAwayOrders()
            { RestaurantId = restaurantId, From = from, To = to });

        return Ok(orders);
    }

    [HttpGet("take-away/{orderId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<TakeAwayOrderDto>> GetTakeAwayOrder(Guid restaurantId, Guid orderId)
    {
        var order = await getTakeAwayOrder.HandleAsync(new GetTakeAwayOrder()
            { RestaurantId = restaurantId, OrderId = orderId });
        return Ok(order);
    }


    [HttpPost("take-away")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateTakeAwayOrder(Guid restaurantId, CreateTakeAwayOrder command)
    {
        var orderId = Guid.NewGuid();
        await createTakeAwayOrder.HandleAsync(command with { OrderId = orderId, RestaurantId = restaurantId });
        return CreatedAtAction(nameof(GetTakeAwayOrder), new { restaurantId = restaurantId, orderId = orderId }, null);
    }

    [HttpGet("delivery")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<IEnumerable<DeliveryOrderDto>>> GetDeliveryOrders(Guid restaurantId,
        [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var orders = await getDeliveryOrders.HandleAsync(new GetDeliveryOrders()
            { RestaurantId = restaurantId, From = from, To = to });
        return Ok(orders);
    }

    [HttpGet("delivery/{orderId:guid}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<DeliveryOrderDto>> GetDeliveryOrder(Guid restaurantId, Guid orderId)
    {
        var order = await getDeliveryOrder.HandleAsync(new GetDeliveryOrder()
            { RestaurantId = restaurantId, OrderId = orderId });
        return Ok(order);
    }

    [HttpPost("delivery")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateDeliveryOrder(Guid restaurantId, CreateDeliveryOrder command)
    {
        var orderId = Guid.NewGuid();
        await createDeliveryOrder.HandleAsync(command with { OrderId = orderId, RestaurantId = restaurantId });
        return CreatedAtAction(nameof(GetDeliveryOrder), new { restaurantId = restaurantId, orderId = orderId }, null);
    }


    [HttpPatch("{orderId:guid}/state")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> ChangeOrderState(Guid restaurantId, Guid orderId, ChangeOrderState command)
    {
        await changeOrderState.HandleAsync(command with { RestaurantId = restaurantId, OrderId = orderId });
        return Accepted();
    }

    [HttpPatch("{orderId:guid}/checkout")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> CheckoutTheOrder(Guid restaurantId, Guid orderId, CheckoutTheOrder command)
    {
        await checkoutTheOrder.HandleAsync(command with { RestaurantId = restaurantId, OrderId = orderId });
        return Accepted();
    }

    [HttpPatch("{orderId:guid}/settle")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> SettleTheOrder(Guid restaurantId, Guid orderId, SettleTheOrder command)
    {
        await settleTheOrder.HandleAsync(
            command with { RestaurantId = restaurantId, OrderId = orderId });
        return Accepted();
    }

    [HttpDelete("{orderId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteOrder(Guid restaurantId, Guid orderId)
    {
        await deleteOrder.HandleAsync(new DeleteOrder()
            { RestaurantId = restaurantId, OrderId = orderId });

        return NoContent();
    }
}