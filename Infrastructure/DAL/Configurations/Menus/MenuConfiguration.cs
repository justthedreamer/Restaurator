using Core.Model.MenuModel;
using Core.ValueObject.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Menus;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(x => x.MenuId)
            .HasConversion(x => x.Value, x => new MenuId(x));

        builder.HasKey(x => x.MenuId);
        
        builder.HasMany(x => x.MenuItems)
            .WithOne();
    }
}