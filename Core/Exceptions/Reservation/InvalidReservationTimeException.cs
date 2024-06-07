using Core.Exceptions.User;

namespace Core.Exceptions.Reservation;

public class InvalidReservationTimeException() : BadRequestException("Invalid reservation time.");
