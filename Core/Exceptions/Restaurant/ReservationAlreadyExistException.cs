namespace Core.Exceptions.Restaurant;

public class ReservationAlreadyExistException() : ConflictException("Reservation already exist.");