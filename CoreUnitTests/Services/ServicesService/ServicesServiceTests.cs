using Core.Exceptions.Policies;
using Core.Policies;
using Core.Services.Abstraction;
using Core.ValueObject.Price;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.ServicesService;

public class ServicesServiceTests
{
    [Fact]
    public void change_service_name_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var service = ServiceFactory.CreateService();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _servicesService.ChangeServiceName(service,"Service Test Name",UserRole.Employee);
        });
    }

    [Fact]
    public void change_service_price_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var service = ServiceFactory.CreateService();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _servicesService.ChangeServicePrice(service,new Price(100),UserRole.Employee);
        });
    }
    
    private readonly IServicesService _servicesService = new Core.Services.ServicesService(new ServicePolicy());
}