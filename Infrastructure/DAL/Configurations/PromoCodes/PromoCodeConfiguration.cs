using Core.Model.PromoCodeModel;
using Core.ValueObject.PromoCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DAL.Configurations.PromoCodes;

public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder.Property(x => x.PromoCodeId)
            .HasConversion(x => x.Value, x => new PromoCodeId(x));

        builder.HasKey(x => x.PromoCodeId);

        builder.Property(x => x.PromoCodeName)
            .HasConversion(x => x.Value, x => new PromoCodeName(x));

        builder.Property(x => x.PromoCodeState)
            .HasConversion(x => x.Value, x => new PromoCodeState(x));

        builder.Property(x => x.PromoCodeKey)
            .HasConversion(x => x.Value, x => new PromoCodeKey(x));

        builder.Property(x => x.PromoCodeValueType)
            .HasConversion(x => x.Value, x => new PromoCodeValueType(x));

        builder.Property(x => x.PromoCodeValue)
            .HasConversion(x => x.Value, x => new PromoCodeValue(x));

        builder.HasMany(x => x.MenuItems)
            .WithMany();

        builder.HasMany(x => x.Services)
            .WithMany();

        builder
            .HasDiscriminator<string>("PROMO CODE TYPE")
            .HasValue<SpecificDatePromoCode>("SPECIFIC DATE PROMO CODE")
            .HasValue<DayOfWeekPromoCode>("DAY OF WEEK PROMO CODE")
            .HasValue<RangeDatePromoCode>("RANGE DATE PROMO CODE");
    }
}