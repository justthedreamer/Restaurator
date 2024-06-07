using Core.Exceptions.User;

namespace Core.Exceptions.Common;

public class InvalidEmailException(string value) : BadRequestException($"Invalid email {value}");
