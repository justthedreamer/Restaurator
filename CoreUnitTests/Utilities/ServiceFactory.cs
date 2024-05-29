using Core.Model.ServicesModel;
using Core.ValueObject.Price;

namespace CoreUnitTests.Utilities;

public static class ServiceFactory
{
    public static Service CreateService()
    {
        var id = Guid.NewGuid();
        var name = "Service";
        var price = new Price(100);
        
        return new Service(id,name,price);
    }
}