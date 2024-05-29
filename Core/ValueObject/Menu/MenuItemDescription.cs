using Core.Exceptions.Menu;

namespace Core.ValueObject.Menu;

public sealed record MenuItemDescription
{
    public string Value { get; }

    public MenuItemDescription(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidMenuItemDescriptionException();
        }

        Value = value;
    }

    public static implicit operator MenuItemDescription(string value) => new(value);
    public static implicit operator string(MenuItemDescription menuItemDescription) => menuItemDescription.Value;
}