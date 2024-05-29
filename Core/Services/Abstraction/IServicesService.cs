using Core.Model.ServicesModel;
using Core.ValueObject.Price;
using Core.ValueObject.Service;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

/// <summary>
/// Services service interface
/// </summary>
public interface IServicesService
{
    /// <summary>
    /// Change service name
    /// </summary>
    /// <param name="service">Service</param>
    /// <param name="serviceName">New service name</param>
    /// <param name="userRole">Requesting User role</param>
    void ChangeServiceName(Service service, ServiceName serviceName, UserRole userRole);

    /// <summary>
    /// Change service price
    /// </summary>
    /// <param name="service">Service</param>
    /// <param name="servicePrice">New service price</param>
    /// <param name="userRole">Requesting User role</param>
    void ChangeServicePrice(Service service, Price servicePrice, UserRole userRole);
}