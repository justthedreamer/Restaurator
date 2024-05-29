using Core.Exceptions.Service;

namespace Core.ValueObject.Service;

public sealed record ServiceName
{
    public string Value { get; }

    public ServiceName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidServiceNameException();
        }

        Value = value;
    }


    public static implicit operator ServiceName(string value) => new(value);
    public static implicit operator string(ServiceName serviceName) => serviceName.Value;
}