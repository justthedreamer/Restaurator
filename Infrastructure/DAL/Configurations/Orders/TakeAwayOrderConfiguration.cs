using Core.Model.OrderModel;
using Core.ValueObject.Staff.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Orders;

public class TakeAwayOrderConfiguration : IEntityTypeConfiguration<TakeAwayOrder>
{
    public void Configure(EntityTypeBuilder<TakeAwayOrder> builder)
    {
        builder.Property(x => x.CustomerFirstName)
            .HasConversion(x => x.Value, x => new FirstName(x));
        
        builder.Property(x => x.CustomerLastName)
            .HasConversion(x => x.Value, x => new LastName(x));
    }
}