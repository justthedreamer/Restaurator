using Core.Exceptions.User;

namespace Core.Exceptions.Order;

public class InvalidOrderStateException(string value,string? additionalMessage) : BadRequestException($"Invalid order state : {value}.{additionalMessage}"); 