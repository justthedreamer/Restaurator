namespace Core.ValueObject.Merchandise;

public class MerchandiseId
{
    public Guid Value { get; }

    public MerchandiseId(Guid value)
    {
        Value = value;
    }

    public static implicit operator MerchandiseId(Guid value) => new(value);
    public static implicit operator Guid(MerchandiseId merchandiseId) => merchandiseId.Value;

}