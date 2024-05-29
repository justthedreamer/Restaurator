namespace Core.ValueObject.Staff.User;

public sealed record UserId
{
    public Guid Value { get; }

    public UserId(Guid value)
    {
        Value = value;
    }

    public static implicit operator UserId(Guid value) => new(value);
    public static implicit operator Guid(UserId userId) => userId.Value;
}