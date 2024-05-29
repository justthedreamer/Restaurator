namespace Core.ValueObject.Restaurant;

public sealed record TableId
{
    public Guid Value { get; }

    public TableId(Guid value)
    {
        Value = value;
    }

    public static implicit operator TableId(Guid value) => new(value);
    public static implicit operator Guid(TableId tableId) => tableId.Value;
}