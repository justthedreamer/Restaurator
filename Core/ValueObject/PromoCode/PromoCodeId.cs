namespace Core.ValueObject.PromoCode;

public sealed class PromoCodeId
{
    public Guid Value { get; }

    public PromoCodeId(Guid value)
    {
        Value = value;
    }

    public static implicit operator PromoCodeId(Guid value) => new(value);
    public static implicit operator Guid(PromoCodeId promoCodeId) => promoCodeId.Value;
}