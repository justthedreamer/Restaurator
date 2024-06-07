using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeTypeException(string value) : BadRequestException($"Invalid promo code type : {value}");
