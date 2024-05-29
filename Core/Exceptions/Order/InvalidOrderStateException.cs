namespace Core.Exceptions.Order;

public class InvalidOrderStateException(string value,string? additionalMessage) : CustomException($"Invalid order state : {value}.{additionalMessage}"); 