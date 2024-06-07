using Core.Exceptions;

namespace Core;

public class ConflictException(string message) : CustomException(message);
