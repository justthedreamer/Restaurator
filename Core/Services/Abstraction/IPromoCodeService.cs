using Core.Model.OrderModel;
using Core.Model.PromoCodeModel;
using Core.Model.RestaurantModel;
using Core.ValueObject.PromoCode;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

public interface IPromoCodeService
{
    /// <summary>
    /// Change promo code value
    /// </summary>
    /// <param name="promoCode">Promo code <see cref="PromoCode"/></param>
    /// <param name="value">New value <see cref="PromoCodeValue"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <param name="restaurantOrders"><see cref="Restaurant"/> orders.</param>
    void ChangePromoCodeValue(PromoCode promoCode, PromoCodeValue value,UserRole userRole,IReadOnlyList<Order> restaurantOrders);

    /// <summary>
    /// Change promo code state
    /// </summary>
    /// <param name="promoCode">Promo code <see cref="PromoCode"/></param>
    /// <param name="state">New state <see cref="PromoCodeState"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    void ChangePromoCodeState(PromoCode promoCode, PromoCodeState state, UserRole userRole);

    /// <summary>
    /// Change dates of <see cref="RangeDatePromoCode"/>
    /// </summary>
    /// <param name="promoCode">Instance of <see cref="RangeDatePromoCode"/></param>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <param name="currentDate">Current date</param>
    /// <param name="userRole">Requesting user roles <see cref="UserRole"/></param>
    /// <param name="restaurantOrders"><see cref="Restaurant"/> orders</param>
    void ChangeRangeDatePromoCodeDates(RangeDatePromoCode promoCode, DateOnly from, DateOnly to, DateOnly currentDate,
        UserRole userRole, IReadOnlyList<Order> restaurantOrders);

    /// <summary>
    /// Change specific date promo code date.
    /// </summary>
    /// <param name="promoCode">Instance of <see cref="SpecificDatePromoCode"/></param>
    /// <param name="date">New date</param>
    /// <param name="currentDate">Current date</param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <param name="restaurantOrders"><see cref="Restaurant"/> orders</param>
    void ChangeSpecificDatePromoCodeDate(SpecificDatePromoCode promoCode, DateOnly date, DateOnly currentDate,
        UserRole userRole, IReadOnlyList<Order> restaurantOrders);
}