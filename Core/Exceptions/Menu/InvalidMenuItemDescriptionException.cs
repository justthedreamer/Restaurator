using Core.Exceptions.User;

namespace Core.Exceptions.Menu;

public class InvalidMenuItemDescriptionException() : BadRequestException("Invalid menu item description.");