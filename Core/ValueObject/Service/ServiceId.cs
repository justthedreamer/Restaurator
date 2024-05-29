namespace Core.ValueObject.Service;

public sealed record ServiceId
{
    public Guid Value { get; }

    public ServiceId(Guid value)
    {
        Value = value;
    }

    public static implicit operator ServiceId(Guid value) => new(value);
    public static implicit operator Guid(ServiceId serviceId) => serviceId.Value;
}