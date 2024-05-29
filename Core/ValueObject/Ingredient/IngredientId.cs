namespace Core.ValueObject.Ingredient;

public sealed record IngredientId
{
    public Guid Value { get; }

    public IngredientId(Guid value)
    {
        Value = value;
    }

    public static implicit operator IngredientId(Guid value) => new(value);
    public static implicit operator Guid(IngredientId ingredientId) => ingredientId.Value;
}