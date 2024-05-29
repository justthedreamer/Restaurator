namespace Core.ValueObject.PromoCode;

public class PromoCodeState
{
    public const string Active = "ACTIVE";
    public const string UnActive = "UNACTIVE";
    
    public string Value { get; }

    public PromoCodeState(string value)
    {
        //todo
        if (value != Active && value != UnActive)
            throw new ArgumentException();
        
        Value = value;
    }

    public static implicit operator PromoCodeState(string value) => new(value);
    public static implicit operator string(PromoCodeState promoCodeState) => promoCodeState.Value;

}