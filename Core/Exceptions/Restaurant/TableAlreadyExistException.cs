namespace Core.Exceptions.Restaurant;

public class TableAlreadyExistException() : ConflictException("Table already exist.");
