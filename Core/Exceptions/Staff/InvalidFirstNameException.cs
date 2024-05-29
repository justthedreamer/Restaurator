namespace Core.Exceptions.Staff;

public class InvalidFirstNameException(string message) : CustomException($"Incorrect First Name format : {message}");
