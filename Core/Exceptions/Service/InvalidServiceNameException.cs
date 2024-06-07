using Core.Exceptions.User;

namespace Core.Exceptions.Service;

public class InvalidServiceNameException() : BadRequestException("Invalid service name exception.");