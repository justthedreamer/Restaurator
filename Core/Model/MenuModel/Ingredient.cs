using Core.ValueObject.Ingredient;
using Core.ValueObject.Price;

namespace Core.Model.MenuModel;
/// <summary>
/// Represents dish ingredient.
/// </summary>
public class Ingredient
{
    public IngredientId IngredientId { get; private set; } = default!;
    public IngredientName IngredientName { get; private set; } = default!;
    public IngredientCategory IngredientCategory { get; private set; } = default!;
    public Price Price { get; private set; } = default!;

    internal void ChangeWholesalePrice(Price price) => Price = price;
    internal void ChangeIngredientCategory(IngredientCategory ingredientCategory) => IngredientCategory = ingredientCategory;
    internal void ChangeIngredientName(IngredientName ingredientName) => IngredientName = ingredientName;

    /// <summary>
    /// Empty constructor for entity framework.
    /// </summary>
    private Ingredient()
    {
    }

    /// <summary>
    /// General constructor.
    /// </summary>
    /// <param name="id">Ingredient ID</param>
    /// <param name="ingredientName">Ingredient Name</param>
    /// <param name="ingredientCategory">Ingredient Category</param>
    /// <param name="price">Ingredient Wholesale price</param>
    public Ingredient(IngredientId id, IngredientName ingredientName, IngredientCategory ingredientCategory, Price price)
    {
        IngredientId = id;
        IngredientName = ingredientName;
        IngredientCategory = ingredientCategory;
        Price = price;
    }
}