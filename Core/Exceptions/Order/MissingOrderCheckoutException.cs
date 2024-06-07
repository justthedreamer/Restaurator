using Core.Exceptions.User;

namespace Core.Exceptions.Order;

public class MissingOrderCheckoutException() : BadRequestException("Missing order checkout.");
