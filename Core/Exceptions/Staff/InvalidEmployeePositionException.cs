using Core.Exceptions.User;

namespace Core.Exceptions.Staff;

public class InvalidEmployeePositionException() : BadRequestException("Invalid employee position.");
