using Core.Exceptions.User;

namespace Core.Exceptions.Price;

public class InvalidPriceException(decimal value) : BadRequestException($"Invalid price : {value}");
