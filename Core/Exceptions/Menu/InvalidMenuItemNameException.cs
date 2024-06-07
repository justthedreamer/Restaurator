using Core.Exceptions.User;

namespace Core.Exceptions.Menu;

public class InvalidMenuItemNameException() : BadRequestException("Invalid menu item name.");
