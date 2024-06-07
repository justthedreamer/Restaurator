using Core.Exceptions.User;

namespace Core.Exceptions.Payment;

public class InvalidPaymentMethodException() : BadRequestException("Invalid payment method.");
