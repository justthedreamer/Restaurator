// using Core.Model.StaffModel;
// using Core.ValueObject.Common;
// using Core.ValueObject.Staff.Employee;
// using Core.ValueObject.Staff.User;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.DAL.Configurations.Staff;
//
// internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
// {
//     public void Configure(EntityTypeBuilder<User> builder)
//     {
//         builder.Property(x => x.UserId)
//             .HasConversion(x => x.Value, x => new UserId(x));
//
//         builder.HasKey(x => x.UserId);
//
//         builder
//             .HasDiscriminator<string>("UserType")
//             .HasValue<Owner>("Owner")
//             .HasValue<Employee>("Employee");
//
//         builder.Property(x => x.UserRole)
//             .HasConversion(x => x.Value, x => new UserRole(x));
//         
//         builder.Property(x => x.FirstName).HasConversion(x => x.Value, x => new FirstName(x));
//
//         builder.Property(x => x.LastName).HasConversion(x => x.Value, x => new LastName(x));
//
//         builder.OwnsOne(x => x.Credentials, p =>
//         {
//             p.Property(x => x.Email).HasConversion(x => x.Value, x => new Email(x));
//
//             p.Property(x => x.Password).HasConversion(x => x.Value, x => new Password(x));
//         });
//     }
// }