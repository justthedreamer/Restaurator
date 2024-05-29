using Core.Exceptions.PromoCode;
using Core.ValueObject.PromoCode;

namespace Core.Model.PromoCodeModel;

/// <summary>
/// Represent Promotional code being recurrence at the day of week.
/// </summary>
public class DayOfWeekPromoCode : PromoCode
{
    public DayOfWeek DayOfWeek { get; private set; }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private DayOfWeekPromoCode() : base()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="promoCodeId"></param>
    /// <param name="promoCodeName"></param>
    /// <param name="promoCodeState"></param>
    /// <param name="promoCodeKey"></param>
    /// <param name="promoCodeValueType"></param>
    /// <param name="promoCodeValue"></param>
    /// <param name="dayOfWeek"></param>
    private DayOfWeekPromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName, PromoCodeState promoCodeState,
        PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType, PromoCodeValue promoCodeValue,
        DayOfWeek dayOfWeek) : base(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
        promoCodeValue)
    {
        DayOfWeek = dayOfWeek;
    }

    /// <summary>
    /// Factory method
    /// </summary>
    /// <param name="promoCodeId"></param>
    /// <param name="promoCodeName"></param>
    /// <param name="promoCodeState"></param>
    /// <param name="promoCodeKey"></param>
    /// <param name="promoCodeValueType"></param>
    /// <param name="promoCodeValue"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    /// <exception cref="InvalidPromoCodeValueException"></exception>
    public static DayOfWeekPromoCode CreateDayOfWeekPromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName,
        PromoCodeState promoCodeState, PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType,
        PromoCodeValue promoCodeValue, DayOfWeek dayOfWeek)
    {
        var isValid = ValidateGivenValue(promoCodeValueType, promoCodeValue);
        if (!isValid)
        {
            throw new PromoCodeInvalidArgumentsException(promoCodeValueType, promoCodeValue);
        }

        return new DayOfWeekPromoCode(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
            promoCodeValue, dayOfWeek);
    }
}