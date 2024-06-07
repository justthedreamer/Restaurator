using Core.Exceptions.User;

namespace Core.Exceptions.Payment;

public class InvalidPaymentStateException() : BadRequestException("Invalid payment state.");
