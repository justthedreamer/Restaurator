using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidRangeDatePromoCodeDatesException()
    : BadRequestException("Invalid provided dates for range promo code.");
