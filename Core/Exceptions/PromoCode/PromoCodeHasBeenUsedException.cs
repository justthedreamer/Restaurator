namespace Core.Exceptions.PromoCode;

public class PromoCodeHasBeenUsedException() : CustomException("Promotional code has been used in one of the previous orders. Cannot apply changes.");