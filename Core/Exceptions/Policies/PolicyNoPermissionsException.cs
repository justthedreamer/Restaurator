namespace Core.Exceptions.Policies;

public class PolicyNoPermissionsException() : AuthorizeException("You are not permitted to this action.");
