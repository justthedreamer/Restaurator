namespace Core.Exceptions.User;

public class BadRequestException(string message) : CustomException(message);
