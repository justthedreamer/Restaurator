namespace Core.ValueObject.Menu;

public sealed record MenuItemId
{
    public Guid Value { get; }

    public MenuItemId(Guid value)
    {
        Value = value;
    }

    public static implicit operator MenuItemId(Guid value) => new(value);
    public static implicit operator Guid(MenuItemId menuItemId) => menuItemId.Value;
}