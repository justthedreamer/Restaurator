using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Staff;

public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.Property(x => x.UserId).HasConversion(x => x.Value, x => new UserId(x));

        builder.HasKey(x => x.UserId);
        
        builder.HasMany(x => x.Restaurants)
            .WithOne(x => x.Owner);
        
        builder.Property(x => x.UserRole)
             .HasConversion(x => x.Value, x => new UserRole(x));
        
        builder.OwnsOne(x => x.Credentials, c =>
        {
            c.Property(x => x.Password)
                .HasConversion(x => x.Value, x => new Password(x));
            c.Property(x => x.Email)
                .HasConversion(x => x.Value, x => new Email(x));
        });

        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x));
        
        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x));
    }
}