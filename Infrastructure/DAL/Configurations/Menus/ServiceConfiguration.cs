using Core.Model.ServicesModel;
using Core.ValueObject.Price;
using Core.ValueObject.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Menus;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(x => x.ServiceId)
            .HasConversion(x => x.Value, x => new ServiceId(x));

        builder.HasKey(x => x.ServiceId);

        builder.Property(x => x.ServiceName)
            .HasConversion(x => x.Value, x => new ServiceName(x));

        builder.Property(x => x.ServicePrice)
            .HasConversion(x => x.Value, x => new Price(x));
    }
}