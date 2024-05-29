namespace Core.ValueObject.Finances;

public sealed record ReceiptId
{
    public Guid Value { get; }

    public ReceiptId(Guid value)
    {
        Value = value;
    }

    public static implicit operator ReceiptId(Guid value) => new(value);
    public static implicit operator Guid(ReceiptId receiptId) => receiptId.Value;

}