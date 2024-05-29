using Core.Model.OrderModel;
using Core.ValueObject.Address;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Orders;

public class DeliveryOrderConfiguration : IEntityTypeConfiguration<DeliveryOrder>
{
    public void Configure(EntityTypeBuilder<DeliveryOrder> builder)
    {
        builder.Property(x => x.CustomerFirstName)
            .HasConversion(x => x.Value, x => new FirstName(x));
        
        builder.Property(x => x.CustomerLastName)
            .HasConversion(x => x.Value, x => new LastName(x));

        builder.OwnsOne(x => x.CustomerAddress, ad =>
        {
            ad.Property(x => x.City)
                .HasConversion(x => x.Value, x => new City(x));
            ad.Property(x => x.Street)
                .HasConversion(x => x.Value, x => new Street(x));
            ad.Property(x => x.HouseNumber)
                .HasConversion(x => x.Value, x => new HouseNumber(x));
        });

        builder.Property(x => x.CustomerPhoneNumber)
            .HasConversion(x => x.Value, x => new PhoneNumber(x));

        builder.HasOne(x => x.Courier)
            .WithMany();
    }
}