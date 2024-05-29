namespace Core.ValueObject.Merchandise;

public record MerchandiseEventId
{
    public Guid Value { get; }

    public MerchandiseEventId(Guid value)
    {
        Value = value;
    }

    public static implicit operator MerchandiseEventId(Guid value) => new(value);
    public static implicit operator Guid(MerchandiseEventId merchandiseEventId) => merchandiseEventId.Value;

}