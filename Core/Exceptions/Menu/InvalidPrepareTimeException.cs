using Core.Exceptions.User;

namespace Core.Exceptions.Menu;

public class InvalidPrepareTimeException() : BadRequestException("Invalid prepare time.");