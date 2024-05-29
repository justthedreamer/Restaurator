using Core.Model.RestaurantModel;

namespace Core.Exceptions.Policies;

public class InvalidTableException(string message) : CustomException(message);
