using Core.Model.PromoCodeModel;
using Core.ValueObject.PromoCode;

namespace CoreUnitTests.Utilities;

public static class PromoCodeFactory
{
    public static SpecificDatePromoCode CreateSpecificDatePromoCode()
    {
        var id = Guid.NewGuid();
        var name = "Day of week promo code";
        var state = PromoCodeState.Active;
        var key = "day_of_week";
        var valueType = PromoCodeValueType.Cash;
        var value = new PromoCodeValue(100);
        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(7));
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        
        return SpecificDatePromoCode.CreateSpecificDatePromoCode(id, name, state, key, valueType, value, date,currentDate);
    }
    
    public static RangeDatePromoCode CreateRangeDatePromoCode()
    {
        var id = Guid.NewGuid();
        var name = "Day of week promo code";
        var state = PromoCodeState.Active;
        var key = "day_of_week";
        var valueType = PromoCodeValueType.Cash;
        var value = new PromoCodeValue(100);
        var from = DateOnly.FromDateTime(DateTime.Now);
        var to = from.AddDays(7);
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        
        return RangeDatePromoCode.CreateRangeDatePromoCode(id, name, state, key, valueType, value, from, to,currentDate);
    }

    public static DayOfWeekPromoCode CreateDayOfWeekPromoCode(PromoCodeValueType valueType)
    {
        var id = Guid.NewGuid();
        var name = "Day of week promo code";
        var state = PromoCodeState.Active;
        var key = "day_of_week";
        var value = new PromoCodeValue(50);
        var dayOfWeek = DayOfWeek.Monday;

        return DayOfWeekPromoCode.CreateDayOfWeekPromoCode(id, name, state, key, valueType, value, dayOfWeek);
    }

    public static DayOfWeekPromoCode CreateDayOfWeekPromoCode()
    {
        var id = Guid.NewGuid();
        var name = "Day of week promo code";
        var state = PromoCodeState.Active;
        var key = "day_of_week";
        var valueType = PromoCodeValueType.Cash;
        var value = new PromoCodeValue(100);
        var dayOfWeek = DayOfWeek.Monday;

        return DayOfWeekPromoCode.CreateDayOfWeekPromoCode(id, name, state, key, valueType, value, dayOfWeek);
    }

    public static DayOfWeekPromoCode CreateDayOfWeekPromoCode(PromoCodeState state, PromoCodeValueType valueType,
        PromoCodeValue value, DayOfWeek dayOfWeek)
    {
        var id = Guid.NewGuid();
        var name = "Day of week promo code";
        var key = "day_of_week";

        return DayOfWeekPromoCode.CreateDayOfWeekPromoCode(id, name, state, key, valueType, value, dayOfWeek);
    }
}