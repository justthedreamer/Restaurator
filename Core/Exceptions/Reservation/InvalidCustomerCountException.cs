using Core.Exceptions.User;

namespace Core.Exceptions.Reservation;

public class InvalidCustomerCountException() : BadRequestException("Invalid customer count. Value should be more than 0.");
