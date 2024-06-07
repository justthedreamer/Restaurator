using Core.Exceptions.User;

namespace Core.Exceptions.Restaurant;

public class InvalidSeatsCountException(ushort value) : BadRequestException($"Invalid seats count exception : {value}"); 
