using Core.Model.FinancesModel;
using Core.ValueObject.Price;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.Receipt;

public class ReceiptRowConfiguration : IEntityTypeConfiguration<ReceiptRow>
{
    public void Configure(EntityTypeBuilder<ReceiptRow> builder)
    {
        builder.HasKey(x => x.ReceiptRowId);

        builder.Property(x => x.DefaultPrice)
            .HasConversion(x => x.Value, x => new Price(x));

        builder.Property(x => x.FinalPrice)
            .HasConversion(x => x.Value, x => new Price(x));

        builder.HasDiscriminator<string>("RECEIPT ROW TYPE")
            .HasValue<MenuItemReceiptRow>("MENU ITEM RECEIPT ROW")
            .HasValue<ServiceReceiptRow>("SERVICE RECEIPT ROW");
    }
}