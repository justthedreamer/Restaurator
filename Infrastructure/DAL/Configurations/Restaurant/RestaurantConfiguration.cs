using Core.Model.StaffModel;
using Core.ValueObject.Address;
using Core.ValueObject.Restaurant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Restaurant;

public class RestaurantConfiguration : IEntityTypeConfiguration<Core.Model.RestaurantModel.Restaurant>
{
    public void Configure(EntityTypeBuilder<Core.Model.RestaurantModel.Restaurant> builder)
    {
        builder.Property(x => x.RestaurantId)
            .HasConversion(x => x.Value, x => new RestaurantId(x));

        builder.HasKey(x => x.RestaurantId);

        builder.Property(x => x.RestaurantName)
            .HasConversion(x => x.Value, x => new RestaurantName(x));
        
        builder.HasOne<Owner>()
            .WithMany(x => x.Restaurants);

        builder.OwnsOne(x => x.Address, a =>
        {
            a.Property(x => x.City).HasConversion(x => x.Value, x => new City(x));
            a.Property(x => x.Street).HasConversion(x => x.Value, x => new Street(x));
            a.Property(x => x.HouseNumber).HasConversion(x => x.Value, x => new HouseNumber(x));
        });

        builder.OwnsMany(x => x.PublicPhoneNumbers, p =>
        {
            p.Property(pn => pn.Value).HasColumnName("PhoneNumber").IsRequired();
        });

      
        builder.OwnsMany(x => x.PublicEmails, p =>
        {
            p.Property(em => em.Value).HasColumnName("Email").IsRequired();
        });

        builder.HasMany(x => x.Tables);

        builder
            .HasMany(x => x.Orders)
            .WithOne()
            .HasForeignKey(o => o.RestaurantId);

        builder.HasMany(x => x.PromoCodes)
            .WithOne()
            .HasForeignKey(p => p.RestaurantId);
        
        builder
            .HasMany(x => x.Employees)
            .WithOne()
            .HasForeignKey(e => e.RestaurantId);

        builder
            .HasMany(x => x.Reservations)
            .WithOne()
            .HasForeignKey(r => r.RestaurantId);

        builder
            .HasMany(x => x.Schedules)
            .WithOne()
            .HasForeignKey(s => s.RestaurantId);

        builder
            .HasMany(x => x.Services)
            .WithOne();
        
        builder.HasOne(x => x.Menu);
    }
}