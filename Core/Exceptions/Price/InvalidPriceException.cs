using Core.Exceptions.User;

namespace Core.Exceptions.Price;

public class InvalidPriceException(double value) : BadRequestException($"Invalid price : {value}");
