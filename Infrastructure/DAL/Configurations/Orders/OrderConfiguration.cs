using Core.Model.OrderModel;
using Core.ValueObject.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.OrderId)
            .HasConversion(x => x.Value, x => new OrderId(x));

        builder.HasKey(x => x.OrderId);

        builder.Property(x => x.OrderNumber)
            .HasConversion(x => x.Value, x => new OrderNumber(x));

        builder.Property(x => x.OrderNumber)
            .UseIdentityColumn();
        
        builder.Property(x => x.OrderType)
            .HasConversion(x => x.Value, x => new OrderType(x));

        builder.Property(x => x.OrderState)
            .HasConversion(x => x.Value, x => new OrderState(x));

        builder.Property(x => x.CreatedAt)
            .HasConversion(x => x.Value, x => new OrderCreateDate(x));

        builder.HasMany(x => x.MenuItems)
            .WithMany();

        builder.HasMany(x => x.Services)
            .WithMany();

        builder.HasOne(x => x.PromoCode)
            .WithMany();

        builder.Property(x => x.OrderMessage)
            .HasConversion(x => x == null ? null : x.Value, x => x == null ? null : new OrderMessage(x));

        builder.HasOne(x => x.Receipt);

        builder
            .HasDiscriminator<OrderType>("OrderType")
            .HasValue<RestaurantOrder>("RESTAURANT ORDER")
            .HasValue<TakeAwayOrder>("TAKE AWAY ORDER")
            .HasValue<DeliveryOrder>("DELIVERY ORDER");

        builder.Property(x => x.IsDeleted)
            .HasDefaultValue(false);
    }
}