namespace Core.Exceptions.Staff;

public class InvalidLastNameException(string message) : CustomException($"Incorrect Last Name format : {message}");

