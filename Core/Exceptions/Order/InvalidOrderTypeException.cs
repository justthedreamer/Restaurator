namespace Core.Exceptions.Order;

public class InvalidOrderTypeException(string value) : CustomException($"Invalid order type : {value}");