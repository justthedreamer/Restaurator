using Core.Exceptions.User;
using Core.Model.RestaurantModel;

namespace Core.Exceptions.Policies;

public class InvalidTableException(string message) : BadRequestException(message);
