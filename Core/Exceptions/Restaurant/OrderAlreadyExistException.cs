namespace Core.Exceptions.Restaurant;

public class OrderAlreadyExistException() : ConflictException("Order already exist.");