using Core.Model.ReservationModel;
using Core.ValueObject.Reservation;
using Core.ValueObject.Staff.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Restaurant;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(x => x.ReservationId)
            .HasConversion(x => x.Value, x => new ReservationId(x));

        builder.HasKey(x => x.ReservationId);

        builder.HasOne(x => x.Table)
            .WithMany();
        
        builder.Property(x => x.CustomerFirstName)
            .HasConversion(x => x.Value, x => new FirstName(x));

        builder.Property(x => x.CustomerLastName)
            .HasConversion(x => x.Value, x => new LastName(x));

        builder.Property(x => x.ReservationDate)
            .HasConversion(x => x.Value, x => new ReservationDate(x));

        builder.Property(x => x.ReservationTime)
            .HasConversion(x => x.Value, x => new ReservationTime(x));

        builder.Property(x => x.CustomerCount)
            .HasConversion(x => x.Value, x => new CustomerCount(x));
        
    }
}