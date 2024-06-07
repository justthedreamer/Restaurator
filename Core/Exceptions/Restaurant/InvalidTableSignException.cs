using Core.Exceptions.User;

namespace Core.Exceptions.Restaurant;

public class InvalidTableSignException() : BadRequestException("Invalid table sign.");
