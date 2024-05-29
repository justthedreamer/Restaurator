namespace Core.Exceptions.Price;

public class InvalidPriceException(double value) : CustomException($"Invalid price : {value}");
