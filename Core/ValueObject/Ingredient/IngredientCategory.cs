using Core.Exceptions.Menu;

namespace Core.ValueObject.Ingredient;

public sealed record IngredientCategory
{
    public string Value { get; }

    public IngredientCategory(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new InvalidIngredientCategoryException();
        }

        Value = value;
    }

    public static implicit operator IngredientCategory(string value) => new(value);
    public static implicit operator string(IngredientCategory ingredientCategory) => ingredientCategory.Value;
};