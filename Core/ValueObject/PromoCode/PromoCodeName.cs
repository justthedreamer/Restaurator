using Core.Exceptions.PromoCode;

namespace Core.ValueObject.PromoCode;

public sealed class PromoCodeName
{
    public string Value { get; }

    public PromoCodeName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidPromoCodeNameException();
        }

        Value = value;
    }

    public static implicit operator PromoCodeName(string value) => new(value);
    public static implicit operator string(PromoCodeName promoCodeName) => promoCodeName.Value;
}