using Core.Exceptions;

namespace Application.Exceptions;

public class RestaurantNotFoundException() : NotFoundException("Restaurant not found.");
