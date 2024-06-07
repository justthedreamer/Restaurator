using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeValueException() : BadRequestException("Invalid promo code value.");