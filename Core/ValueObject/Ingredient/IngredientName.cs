using Core.Exceptions.Menu;

namespace Core.ValueObject.Ingredient;

public sealed record IngredientName
{
    public string Value { get; }

    public IngredientName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidIngredientNameException();
        }

        Value = value;
    }

    public static implicit operator IngredientName(string value) => new(value);
    public static implicit operator string(IngredientName ingredientName) => ingredientName.Value;
}