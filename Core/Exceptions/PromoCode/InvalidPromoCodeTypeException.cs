namespace Core.Exceptions.PromoCode;

public class InvalidPromoCodeTypeException(string value) : CustomException($"Invalid promo code type : {value}");
