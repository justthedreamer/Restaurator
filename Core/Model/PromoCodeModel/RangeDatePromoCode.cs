using Core.Exceptions.PromoCode;
using Core.ValueObject.PromoCode;

namespace Core.Model.PromoCodeModel;

public class RangeDatePromoCode : PromoCode
{
    public DateOnly From { get; private set; }
    public DateOnly To { get; private set; }

    /// <summary>
    /// Change dates
    /// </summary>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <param name="currentDate">Current date</param>
    /// <exception cref="InvalidRangeDatePromoCodeDatesException">If provided range is incorrect.</exception>
    internal void ChangeDates(DateOnly from, DateOnly to, DateOnly currentDate)
    {
        var isValid = ValidateGivenDates(from, to, currentDate);
        if (!isValid)
            throw new InvalidRangeDatePromoCodeDatesException();

        From = from;
        To = to;
    }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected RangeDatePromoCode()
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
    /// <param name="from"></param>
    /// <param name="to"></param>
    protected RangeDatePromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName, PromoCodeState promoCodeState,
        PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType, PromoCodeValue promoCodeValue, DateOnly from,
        DateOnly to) : base(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
        promoCodeValue)
    {
        From = from;
        To = to;
    }

    /// <summary>
    /// Factory method
    /// </summary>
    /// <param name="promoCodeId">Promo code ID <see cref="PromoCodeId"/></param>
    /// <param name="promoCodeName">Promo code name <see cref="PromoCodeName"/></param>
    /// <param name="promoCodeState">Promo code state <see cref="PromoCodeState"/></param>
    /// <param name="promoCodeKey">Promo code key <see cref="PromoCodeKey"/></param>
    /// <param name="promoCodeValueType">Promo code value type <see cref="PromoCodeValueType"/></param>
    /// <param name="promoCodeValue">Promo code value <see cref="PromoCodeValue"/></param>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <param name="currentDate">Current date</param>
    /// <returns>New instance of <see cref="RangeDatePromoCode"/></returns>
    /// <exception cref="InvalidPromoCodeValueException"></exception>
    /// <exception cref="InvalidRangeDatePromoCodeDatesException"></exception>
    public static RangeDatePromoCode CreateRangeDatePromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName,
        PromoCodeState promoCodeState, PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType,
        PromoCodeValue promoCodeValue, DateOnly from, DateOnly to, DateOnly currentDate)
    {
        var isValid = ValidateGivenValue(promoCodeValueType, promoCodeValue);
        if (!isValid)
        {
            throw new PromoCodeInvalidArgumentsException(promoCodeValueType, promoCodeValue);
        }

        var isDatesValid = ValidateGivenDates(from, to, currentDate);
        if (!isDatesValid)
            throw new InvalidRangeDatePromoCodeDatesException();

        return new RangeDatePromoCode(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
            promoCodeValue, from, to);
    }

    /// <summary>
    /// Validate given dates.
    /// </summary>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <param name="currentDate">Current date</param>
    /// <returns>True if valid, false if not</returns>
    private static bool ValidateGivenDates(DateOnly from, DateOnly to, DateOnly currentDate)
    {
        return (from >= currentDate) && (to > from);
    }
}