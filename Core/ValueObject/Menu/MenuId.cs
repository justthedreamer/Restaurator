namespace Core.ValueObject.Menu;

public sealed record MenuId
{
    public Guid Value { get; }

    public MenuId(Guid value)
    {
        Value = value;
    }

    public static implicit operator MenuId(Guid value) => new(value);
    public static implicit operator Guid(MenuId menuId) => menuId.Value;
}