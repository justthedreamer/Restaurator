using Core.Exceptions.Policies;
using Core.Exceptions.PromoCode;
using Core.Model.OrderModel;
using Core.Model.PromoCodeModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.PromoCode;
using Core.ValueObject.Staff.User;

namespace Core.Services;

internal sealed class PromoCodeService(IPromoCodePolicy promoCodePolicy) : IPromoCodeService
{
    ///  <summary>
    ///  Change promo code value
    ///  </summary>
    ///  <param name="promoCode">Promo code <see cref="PromoCode"/></param>
    ///  <param name="value">New value <see cref="PromoCodeValue"/></param>
    ///  <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    ///  <param name="restaurantOrders">Restaurant orders.</param>
    ///  <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change value.</exception>
    ///  <exception cref="PromoCodeHasBeenUsedException">If provided promo code has been used in any of previous order.</exception>
    ///  <exception cref="InvalidPromoCodeValueException">If provided promo code value is not assignable to promo code value type.<see cref="PromoCode"/></exception>
    public void ChangePromoCodeValue(PromoCode promoCode, PromoCodeValue value, UserRole userRole,
        IReadOnlyList<Order> restaurantOrders)
    {
        var isPermitted = promoCodePolicy.IsInRole(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var hasBeenUsed = PromoCodeHasBeenUsed(promoCode, restaurantOrders);
        if (hasBeenUsed)
            throw new PromoCodeHasBeenUsedException();

        promoCode.ChangePromoCodeValue(value);
    }

    /// <summary>
    /// Change promo code state
    /// </summary>
    /// <param name="promoCode">Promo code <see cref="PromoCode"/></param>
    /// <param name="state">New state <see cref="PromoCodeState"/></param>
    /// <param name="userRole">Requesting user role <see cref="UserRole"/></param>
    /// <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change state.</exception>
    public void ChangePromoCodeState(PromoCode promoCode, PromoCodeState state, UserRole userRole)
    {
        var isPermitted = promoCodePolicy.IsInRole(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        promoCode.ChangePromoCodeState(state);
    }

    /// <summary>
    /// Change dates of <see cref="RangeDatePromoCode"/>
    /// </summary>
    /// <param name="promoCode">Instance of <see cref="RangeDatePromoCode"/></param>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <param name="currentDate">Current date</param>
    /// <param name="userRole">Requesting user roles <see cref="UserRole"/></param>
    /// <param name="restaurantOrders">Restaurant orders</param>
    /// <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change value.</exception>
    ///  <exception cref="PromoCodeHasBeenUsedException">If provided promo code has been used in any of previous order.</exception>
    /// <exception cref="InvalidRangeDatePromoCodeDatesException">If provided range is incorrect. <see cref="RangeDatePromoCode"/></exception>
    public void ChangeRangeDatePromoCodeDates(RangeDatePromoCode promoCode, DateOnly from, DateOnly to,
        DateOnly currentDate,
        UserRole userRole, IReadOnlyList<Order> restaurantOrders)
    {
        var isPermitted = promoCodePolicy.IsInRole(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var hasBeenUsed = PromoCodeHasBeenUsed(promoCode, restaurantOrders);
        if (hasBeenUsed)
            throw new PromoCodeHasBeenUsedException();

        promoCode.ChangeDates(from, to, currentDate);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <summary>
    /// Change dates of <see cref="RangeDatePromoCode"/>
    /// </summary>
    /// <param name="promoCode">Instance of <see cref="RangeDatePromoCode"/></param>
    /// <param name="date">New date</param>
    /// <param name="currentDate">Current date</param>
    /// <param name="userRole">Requesting user roles <see cref="UserRole"/></param>
    /// <param name="restaurantOrders">Restaurant orders</param>
    /// <exception cref="PolicyNoPermissionsException">If requesting user is not permitted to change value.</exception>
    ///  <exception cref="PromoCodeHasBeenUsedException">If provided promo code has been used in any of previous order.</exception>
    /// <exception cref="InvalidSpecificDatePromoCodeDateException">Throw if provided date incorrect. <see cref="SpecificDatePromoCode"/></exception>
    public void ChangeSpecificDatePromoCodeDate(SpecificDatePromoCode promoCode, DateOnly date, DateOnly currentDate,
        UserRole userRole, IReadOnlyList<Order> restaurantOrders)
    {
        var isPermitted = promoCodePolicy.IsInRole(userRole);

        if (!isPermitted)
            throw new PolicyNoPermissionsException();

        var hasBeenUsed = PromoCodeHasBeenUsed(promoCode, restaurantOrders);
        if (hasBeenUsed)
            throw new PromoCodeHasBeenUsedException();

        promoCode.ChangeDate(date, currentDate);
    }

    /// <summary>
    /// Check if promo code has been used is some order.
    /// </summary>
    /// <param name="promoCode">Promo code</param>
    /// <param name="orders">List of orders.</param>
    /// <returns>True or false.</returns>
    private bool PromoCodeHasBeenUsed(PromoCode promoCode, IReadOnlyList<Order> orders) =>
        orders.Any(x => x.PromoCode?.PromoCodeId == promoCode.PromoCodeId);
}