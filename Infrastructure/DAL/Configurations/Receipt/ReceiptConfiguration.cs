using Core.ValueObject.Finances;
using Core.ValueObject.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Receipt;

internal sealed class ReceiptConfiguration : IEntityTypeConfiguration<Core.Model.FinancesModel.Receipt>
{
    public void Configure(EntityTypeBuilder<Core.Model.FinancesModel.Receipt> builder)
    {
        builder.Property(x => x.ReceiptId)
            .HasConversion(x => x.Value, x => new ReceiptId(x));

        builder.HasKey(x => x.ReceiptId);

        builder.HasMany(x => x.MenuItemReceiptRows)
            .WithOne();

        builder.HasMany(x => x.ServiceReceiptRows)
            .WithOne();

        builder.Property(x => x.PaymentMethod)
            .HasConversion(x => x == null ? null : x.Value, x => x == null ? null : new PaymentMethod(x));

        builder.Property(x => x.PaymentState)
            .HasConversion(x => x == null ? null : x.Value, x => x == null ? null : new PaymentState(x));
    }
}