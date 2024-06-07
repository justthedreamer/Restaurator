using Core.Exceptions;

namespace Application.Exceptions;

public class UserNotFoundException() : NotFoundException("User not found.");
