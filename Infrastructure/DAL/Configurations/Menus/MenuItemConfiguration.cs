using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Menus;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.Property(x => x.MenuItemId)
            .HasConversion(x => x.Value, x => new MenuItemId(x));

        builder.HasKey(x => x.MenuItemId);

        builder.Property(x => x.MenuItemName)
            .HasConversion(x => x.Value, x => new MenuItemName(x));
        
        builder.Property(x => x.Category)
            .HasConversion(x => x.Value, x => new MenuItemCategory(x));

        builder.Property(x => x.RetailPrice)
            .HasConversion(x => x.Value, x => new Price(x));

        builder.HasMany(x => x.Ingredients)
            .WithMany();

        builder.Property(x => x.Description)
            .HasConversion(x => x == null ? null : x.Value, x => x == null ? null : new MenuItemDescription(x));

        builder.Property(x => x.PrepareTime)
            .HasConversion(x => x == null ? null : x.Value, x => x == null ? null : new PrepareTime(x));
        
        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}