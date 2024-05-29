using Core.Exceptions.Menu;

namespace Core.ValueObject.Menu;

public sealed record MenuItemCategory
{
    public string Value { get; }

    public MenuItemCategory(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidMenuItemCategory();
        }

        Value = value;
    }

    public static implicit operator MenuItemCategory(string value) => new(value);
    public static implicit operator string(MenuItemCategory menuItemCategory) => menuItemCategory.Value;
}