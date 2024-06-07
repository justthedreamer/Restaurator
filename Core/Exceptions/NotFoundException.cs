namespace Core.Exceptions;

public abstract class NotFoundException(string message) : CustomException(message);
