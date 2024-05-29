namespace Core.Exceptions.Common;

public class InvalidEmailException(string value) : CustomException($"Invalid email {value}");
