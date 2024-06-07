using Core.Exceptions.User;

namespace Core.Exceptions.Address;

public class InvalidHouseNumberException() : BadRequestException("Invalid house number.");
