using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeFlagException() : BadRequestException("Invalid promo code flag.");