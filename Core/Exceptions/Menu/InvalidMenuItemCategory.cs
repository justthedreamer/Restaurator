using Core.Exceptions.User;

namespace Core.Exceptions.Menu;

public class InvalidMenuItemCategory() : BadRequestException("Invalid menu item category.");