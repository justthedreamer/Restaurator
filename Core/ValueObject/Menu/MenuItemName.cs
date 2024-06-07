using Core.Exceptions.Menu;

namespace Core.ValueObject.Menu;

public record MenuItemName
{
    public string Value { get; }

    public MenuItemName(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidMenuItemNameException();
        Value = value;
    }

    public static implicit operator MenuItemName(string value) => new(value);
    public static implicit operator string(MenuItemName menuItemName) => menuItemName.Value;
}