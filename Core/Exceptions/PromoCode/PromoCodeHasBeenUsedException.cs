using Core.Exceptions.User;

namespace Core.Exceptions.PromoCode;

public class PromoCodeHasBeenUsedException() : BadRequestException("Promotional code has been used in one of the previous orders. Cannot apply changes.");