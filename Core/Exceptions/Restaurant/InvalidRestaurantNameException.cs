using Core.Exceptions.User;

namespace Core.Exceptions.Restaurant;

public class InvalidRestaurantNameException() : BadRequestException("Invalid restaurant name.");
