using Core.Exceptions.PromoCode;

namespace Core.ValueObject.PromoCode;

public sealed record PromoCodeValueType
{
    public const string Percentage = "Percentage";
    public const string Cash = "Cash";

    public string Value { get; }

    public PromoCodeValueType(string value)
    {
        var isValid = value == Percentage || value == Cash;
        
        if (!isValid)
        {
            throw new InvalidPromoCodeTypeException(value);
        }

        Value = value;
    }

    public static implicit operator PromoCodeValueType(string value) => new(value);
    public static implicit operator string(PromoCodeValueType promoCodeValueType) => promoCodeValueType.Value;

}