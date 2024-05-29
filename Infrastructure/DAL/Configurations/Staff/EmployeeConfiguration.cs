using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Core.ValueObject.Staff.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Staff;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.UserId).HasConversion(x => x.Value, x => new UserId(x));

        builder.HasKey(x => x.UserId);
        
        builder.Property(x => x.UserRole)
            .HasConversion(x => x.Value, x => new UserRole(x));
        
        builder.Property(x => x.EmployeeLogin)
            .HasConversion(x => x.Value, x => new EmployeeLogin(x))
            .IsRequired();

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

        builder.HasIndex(x => x.EmployeeLogin)
            .IsUnique();

        builder.Property(x => x.EmployeePosition)
            .HasConversion(x => x.Value, x => new EmployeePosition(x));

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}