using Core.Exceptions.PromoCode;

namespace Core.ValueObject.PromoCode;

public sealed class PromoCodeKey
{
    public string Value { get; }

    public PromoCodeKey(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidPromoCodeKeyException();
        }

        Value = value;
    }

    public static implicit operator PromoCodeKey(string value) => new(value);
    public static implicit operator string(PromoCodeKey promoCodeKey) => promoCodeKey.Value;
}