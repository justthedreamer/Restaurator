using Core.Exceptions.User;

namespace Core.Exceptions.Order;

public class InvalidOrderTypeException(string value) : BadRequestException($"Invalid order type : {value}");