using Core.Exceptions.PromoCode;

namespace Core.ValueObject.PromoCode;

public sealed record PromoCodeValue
{
    public ushort Value { get; }

    public PromoCodeValue(ushort value)
    {
        if (value == 0)
        {
            throw new InvalidPromoCodeValueException();
        }
        Value = value;
    }

    public static implicit operator PromoCodeValue(ushort value) => new(value);
    public static implicit operator ushort(PromoCodeValue promoCodeValue) => promoCodeValue.Value;
}