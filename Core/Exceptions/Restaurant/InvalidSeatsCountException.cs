namespace Core.Exceptions.Restaurant;

public class InvalidSeatsCountException(ushort value) : CustomException($"Invalid seats count exception : {value}"); 
