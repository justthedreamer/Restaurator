namespace Core.Exceptions.User;

public class InvalidUserRoleException(string userRole) : BadRequestException($"Invalid user role {userRole}.");