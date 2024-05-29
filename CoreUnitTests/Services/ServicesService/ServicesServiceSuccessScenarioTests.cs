using Core.Policies;
using Core.Services;
using Core.Services.Abstraction;
using Core.ValueObject.Price;
using Core.ValueObject.Service;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.ServicesService;

public class ServicesServiceSuccessScenarioTests
{
    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void change_service_name_with_permitted_roles(UserRole userRole)
    {
        //Arrange
        var service = ServiceFactory.CreateService();
        var name = new ServiceName("Service name test");
        
        //Act
        _servicesService.ChangeServiceName(service,name,userRole);
        
        //Assert
        service.ServiceName.ShouldBe(name);
    }
    
    [Theory]
    [InlineData(UserRole.Manager)]
    [InlineData(UserRole.Owner)]
    public void change_service_price_with_permitted_roles(UserRole userRole)
    {
        //Arrange
        var service = ServiceFactory.CreateService();
        var price = new Price(500);
        
        //Act
        _servicesService.ChangeServicePrice(service,price,userRole);
        
        //Assert
        service.ServicePrice.ShouldBe(price);
    }

    private readonly IServicesService _servicesService = new ServicesServiceFailScenario(new ServicePolicy());
}