using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.RestaurantModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Order;

namespace CoreUnitTests.Utilities;

public static class OrderFactory
{
    public static RestaurantOrder CreateRestaurantOrder()
    {
        var id = Guid.NewGuid();
        var orderState = OrderState.Ready;
        
        return new RestaurantOrder(id,orderState,DateTime.Now,new Table(Guid.NewGuid(),"A1",4));
    }
}