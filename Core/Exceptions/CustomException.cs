namespace Core.Exceptions;

public abstract class CustomException(string? message = null) : Exception(message);