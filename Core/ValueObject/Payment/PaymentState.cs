using Core.Exceptions.Payment;

namespace Core.ValueObject.Payment;

public sealed record PaymentState
{
    public const string NotPayed = "NOTPAYED";
    public const string Pending = "PENDING";
    public const string Payed = "PAYED";
    public const string Failed = "FAILED";
    public const string Canceled = "CANCELED";

    public string Value { get; }

    public PaymentState(string value)
    {
        var isValid = value == NotPayed || value == Pending || value == Payed || value == Failed || value == Canceled;

        if (!isValid)
        {
            throw new InvalidPaymentStateException();
        }

        Value = value;
    }

    public static implicit operator PaymentState(string value) => new(value);
    public static implicit operator string(PaymentState paymentState) => paymentState.Value;
}