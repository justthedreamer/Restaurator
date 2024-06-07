using Core.Exceptions.User;

namespace Core.Exceptions.Order;

public class InvalidOrderNumberException() : BadRequestException("Invalid order number.");
