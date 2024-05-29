using Core.Exceptions.PromoCode;
using Core.Model.MenuModel;
using Core.Model.ServicesModel;
using Core.ValueObject.Price;
using Core.ValueObject.PromoCode;

namespace Core.Model.PromoCodeModel;

/// <summary>
/// Represent promotional code
/// </summary>
public abstract class PromoCode
{
    public PromoCodeId PromoCodeId { get; private set; }
    public PromoCodeName PromoCodeName { get; private set; }
    public PromoCodeState PromoCodeState { get; private set; }
    public PromoCodeKey PromoCodeKey { get; private set; }
    public PromoCodeValueType PromoCodeValueType { get; private set; }
    public PromoCodeValue PromoCodeValue { get; private set; }
    public IReadOnlyList<MenuItem> MenuItems { get; protected set; } = new List<MenuItem>();
    public IReadOnlyList<Service> Services { get; protected set; } = new List<Service>();
    public bool IsDeleted { get; private set; } = false;
    
    /// <summary>
    /// Change promo code value.
    /// </summary>
    /// <param name="value">New value</param>
    /// <exception cref="InvalidPromoCodeValueException">If provided value is assignable to value type.</exception>
    internal void ChangePromoCodeValue(PromoCodeValue value)
    {
        var isValid = ValidateGivenValue(PromoCodeValueType, value);

        if (!isValid)
            throw new InvalidPromoCodeValueException();

        PromoCodeValue = value;
    }

    /// <summary>
    /// Change promo code state.
    /// </summary>
    /// <param name="promoCodeState"></param>
    internal void ChangePromoCodeState(PromoCodeState promoCodeState) => PromoCodeState = promoCodeState;

    /// <summary>
    /// Calculate the final price of menu item.
    /// </summary>
    /// <param name="menuItem">Menu item</param>
    /// <returns><see cref="Price"/></returns>
    public Price CalculateFinalPrice(MenuItem menuItem)
    {
        var item = MenuItems.SingleOrDefault(x => x.MenuItemId == menuItem.MenuItemId);

        if (item is null)
            return menuItem.RetailPrice;

        return CalculatePromotionalPrice(menuItem.RetailPrice);
    }

    /// <summary>
    /// Calculate final price for service
    /// </summary>
    /// <param name="service">Service</param>
    /// <returns><see cref="Price"/></returns>
    public Price CalculateFinalPrice(Service service)
    {
        var item = Services.SingleOrDefault(x => x.ServiceId == service.ServiceId);

        if (item is null)
            return service.ServicePrice;

        return CalculatePromotionalPrice(service.ServicePrice);
    }

    /// <summary>
    /// Calculate promotional price
    /// </summary>
    /// <param name="price">Default price of item/service.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException">Thrown if PromoCodeValueType is not implemented yet.</exception>
    private Price CalculatePromotionalPrice(Price price)
    {
        switch (PromoCodeValueType)
        {
            case PromoCodeValueType.Percentage:
            {
                return price - (price * PromoCodeValue * 0.01);
            }
            case PromoCodeValueType.Cash:
            {
                return price - PromoCodeValue;
            }
            default:
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    protected PromoCode()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="promoCodeId">Promo code ID</param>
    /// <param name="promoCodeName">Promo code type</param>
    /// <param name="promoCodeState">Promo code state</param>
    /// <param name="promoCodeKey">Promo code key</param>
    /// <param name="promoCodeValueType">Promo code type</param>
    /// <param name="promoCodeValue">Promo code value</param>
    protected PromoCode(PromoCodeId promoCodeId, PromoCodeName promoCodeName, PromoCodeState promoCodeState,
        PromoCodeKey promoCodeKey, PromoCodeValueType promoCodeValueType, PromoCodeValue promoCodeValue)
    {
        PromoCodeId = promoCodeId;
        PromoCodeName = promoCodeName;
        PromoCodeState = promoCodeState;
        PromoCodeKey = promoCodeKey;
        PromoCodeValueType = promoCodeValueType;
        PromoCodeValue = promoCodeValue;
    }

    /// <summary>
    /// Validate if provided value is assignable to value type.
    /// </summary>
    /// <param name="valueType">Value type</param>
    /// <param name="value">Value</param>
    /// <returns>True or false</returns>
    protected static bool ValidateGivenValue(PromoCodeValueType valueType, PromoCodeValue value)
    {
        switch (valueType)
        {
            case PromoCodeValueType.Percentage:
            {
                return value >= 1 && value <= 100;
            }
            case PromoCodeValueType.Cash:
            {
                return value > 0;
            }
            default:
                return false;
        }
    }
}