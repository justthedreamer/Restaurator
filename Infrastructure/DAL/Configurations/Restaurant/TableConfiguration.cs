using Core.Model.RestaurantModel;
using Core.ValueObject.Restaurant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Restaurant;

public class TableConfiguration : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.Property(x => x.TableId)
            .HasConversion(x => x.Value, x => new TableId(x));

        builder.Property(x => x.TableSign)
            .HasConversion(x => x.Value, x => new TableSign(x))
            .IsRequired();

        builder.HasIndex(x => x.TableSign)
            .IsUnique();
        
        builder.HasKey(x => x.TableId);

        builder.Property(x => x.SeatsCount)
            .HasConversion(x => x.Value, x => new SeatsCount(x))
            .IsRequired();
    }
}