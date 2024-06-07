using Core.Exceptions.User;

namespace Core.Exceptions.Common;

public class InvalidPasswordException() : BadRequestException("Invalid password.");
