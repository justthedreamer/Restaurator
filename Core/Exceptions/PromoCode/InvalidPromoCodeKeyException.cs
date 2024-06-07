using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeKeyException() : BadRequestException("Invalid promo code key.");
