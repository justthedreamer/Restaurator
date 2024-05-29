using Core.Exceptions.Policies;
using Core.Model.ServicesModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Price;
using Core.ValueObject.Service;
using Core.ValueObject.Staff.User;


namespace Core.Services;

/// <summary>
/// Services service implementation
/// </summary>
internal class ServicesServiceFailScenario(IServicePolicy servicePolicy) : IServicesService
{
    /// <summary>
    /// Change service name
    /// </summary>
    /// <param name="service">Service</param>
    /// <param name="serviceName">New service name</param>
    /// <param name="userRole">Requesting User role</param>
    /// <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change service name.</exception>
    public void ChangeServiceName(Service service, ServiceName serviceName, UserRole userRole)
    {
        var isPermitted = servicePolicy.IsPermitted(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        service.ChangeServiceName(serviceName);
    }

    /// <summary>
    /// Change service price
    /// </summary>
    /// <param name="service">Service</param>
    /// <param name="servicePrice">New service price</param>
    /// <param name="userRole">Requesting User role</param>
    /// <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change service name.</exception>
    public void ChangeServicePrice(Service service, Price servicePrice, UserRole userRole)
    {
        var isPermitted = servicePolicy.IsPermitted(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        service.ChangeServicePrice(servicePrice);
    }
}