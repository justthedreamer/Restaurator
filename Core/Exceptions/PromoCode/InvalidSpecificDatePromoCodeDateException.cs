namespace Core.Exceptions.PromoCode;

public class InvalidSpecificDatePromoCodeDateException() : CustomException("Invalid provided date for specific date promo code. Date should be located in future.");