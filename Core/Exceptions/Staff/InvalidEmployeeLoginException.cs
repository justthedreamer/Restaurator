using Core.Exceptions.User;

namespace Core.Exceptions.Staff;

public class InvalidEmployeeLoginException() : BadRequestException($"Invalid employee login.");
