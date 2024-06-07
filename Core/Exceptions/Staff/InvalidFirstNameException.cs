using Core.Exceptions.User;

namespace Core.Exceptions.Staff;

public class InvalidFirstNameException(string message) : BadRequestException($"Incorrect First Name format : {message}");
