using Core.Model.MenuModel;
using Core.ValueObject.Ingredient;
using Core.ValueObject.Price;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Menus;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.Property(x => x.IngredientId)
            .HasConversion(x => x.Value, x => new IngredientId(x));

        builder.Property(x => x.IngredientName)
            .HasConversion(x => x.Value, x => new IngredientName(x));

        builder.Property(x => x.IngredientCategory)
            .HasConversion(x => x.Value, x => new IngredientCategory(x));

        builder.Property(x => x.Price)
            .HasConversion(x => x.Value, x => new Price(x));
    }
}