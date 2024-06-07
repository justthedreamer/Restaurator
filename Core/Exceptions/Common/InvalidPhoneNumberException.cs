using Core.Exceptions.User;

namespace Core.Exceptions.Common;

public class InvalidPhoneNumberException() : BadRequestException("Invalid phone number.");