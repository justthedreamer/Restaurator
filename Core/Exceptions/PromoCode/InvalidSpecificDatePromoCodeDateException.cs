using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class InvalidSpecificDatePromoCodeDateException() : BadRequestException("Invalid provided date for specific date promo code. Date should be located in future.");