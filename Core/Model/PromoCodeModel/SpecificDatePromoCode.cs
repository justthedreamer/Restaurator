using Core.Exceptions.PromoCode;
using Core.ValueObject.Price;
using Core.ValueObject.PromoCode;

namespace Core.Model.PromoCodeModel;

/// <summary>
/// Represent specific date promo code
/// </summary>
public class SpecificDatePromoCode : PromoCode
{
    /// <summary>
    /// Specific date
    /// </summary>
    public DateOnly Date { get; private set; }

    /// <summary>
    /// Change date
    /// </summary>
    /// <param name="date">New date</param>
    /// <param name="currentDate">Current date</param>
    /// <exception cref="InvalidSpecificDatePromoCodeDateException">Throw if provided date incorrect.</exception>
    internal void ChangeDate(DateOnly date, DateOnly currentDate)
    {
        var isDateValid = date >= currentDate;
        if (!isDateValid)
            throw new InvalidSpecificDatePromoCodeDateException();

        Date = date;
    }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected SpecificDatePromoCode()
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
    /// <param name="date"></param>
    protected SpecificDatePromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName, PromoCodeState promoCodeState,
        PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType, PromoCodeValue promoCodeValue,
        DateOnly date) : base(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
        promoCodeValue)
    {
        Date = date;
    }

    /// <summary>
    /// Factory Method
    /// </summary>
    /// <param name="promoCodeId">ID <see cref="PromoCodeId"/></param>
    /// <param name="promoCodeName">Promo code name <see cref="PromoCodeName"/></param>
    /// <param name="promoCodeState">Promo code state <see cref="PromoCodeState"/></param>
    /// <param name="promoCodeKey">Promo code key <see cref="PromoCodeKey"/></param>
    /// <param name="promoCodeValueType">Promo code value type <see cref="PromoCodeValueType"/></param>
    /// <param name="promoCodeValue">Promo code value <see cref="PromoCodeValue"/></param>
    /// <param name="date">Promo code date</param>
    /// <param name="currentDate">Current date</param>
    /// <returns>New instance of <see cref="SpecificDatePromoCode"/></returns>
    /// <exception cref="InvalidPromoCodeValueException"></exception>
    /// <exception cref="InvalidSpecificDatePromoCodeDateException"></exception>
    public static SpecificDatePromoCode CreateSpecificDatePromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName,
        PromoCodeState promoCodeState, PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType,
        PromoCodeValue promoCodeValue, DateOnly date, DateOnly currentDate)
    {
        var isValueValid = ValidateGivenValue(promoCodeValueType, promoCodeValue);

        if (!isValueValid)
        {
            throw new PromoCodeInvalidArgumentsException(promoCodeValueType, promoCodeValue);
        }

        var isDateValid = date >= currentDate;

        if (!isDateValid)
            throw new InvalidSpecificDatePromoCodeDateException();

        return new SpecificDatePromoCode(promoCodeId, promoCodeName, promoCodeState, promoCodeKey, promoCodeValueType,
            promoCodeValue, date);
    }
}