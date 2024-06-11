using Core.Exceptions.Payment;

namespace Core.ValueObject.Payment;

public sealed record PaymentMethod
{
    const string Card = "CARD";
    const string Cash = "CASH";

    public string Value { get; }
    
    public PaymentMethod(string paymentMethod)
    {
        if (paymentMethod != Cash && paymentMethod != Card)
        {
            throw new InvalidPaymentMethodException();
        }

        Value = paymentMethod;
    }

    public static implicit operator PaymentMethod(string value) => new(value);
    public static implicit operator string(PaymentMethod paymentMethod) => paymentMethod.Value;
};