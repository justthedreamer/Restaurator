using Core.Exceptions.User;

namespace Core.Exceptions.Staff;

public class InvalidLastNameException(string message) : BadRequestException($"Incorrect Last Name format : {message}");

