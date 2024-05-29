using Core.Model.MenuModel;
using Core.Model.OrderModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Order;

namespace CoreUnitTests.Utilities;

public static class OrderFactory
{
    public static RestaurantOrder CreateRestaurantOrder()
    {
        var id = Guid.NewGuid();
        var orderState = OrderState.Ready;
        
        return new RestaurantOrder(id,orderState,DateTime.Now,new List<MenuItem>(),new List<Service>(),null);
    }
}