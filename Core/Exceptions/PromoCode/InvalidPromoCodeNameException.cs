using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeNameException() : BadRequestException("Invalid promo code name.");
