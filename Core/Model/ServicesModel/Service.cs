using Core.ValueObject.Price;
using Core.ValueObject.Service;

namespace Core.Model.ServicesModel;

/// <summary>
/// Represent restaurant service
/// </summary>
public class Service
{
    public ServiceId ServiceId { get; private set; }
    public ServiceName ServiceName { get; private set; }
    public Price ServicePrice { get; private set; }

    /// <summary>
    /// Change service name
    /// </summary>
    /// <param name="serviceName">New name</param>
    internal void ChangeServiceName(ServiceName serviceName) => ServiceName = serviceName;

    /// <summary>
    /// Change service price
    /// </summary>
    /// <param name="servicePrice">New price</param>
    internal void ChangeServicePrice(Price servicePrice) => ServicePrice = servicePrice;

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Service()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="serviceName"></param>
    /// <param name="servicePrice"></param>
    public Service(ServiceId serviceId, ServiceName serviceName, Price servicePrice)
    {
        ServiceId = serviceId;
        ServiceName = serviceName;
        ServicePrice = servicePrice;
    }
}