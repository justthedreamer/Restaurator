using Core.Exceptions.User;

namespace Core.Exceptions.Menu;

public class InvalidIngredientCategoryException() : BadRequestException("Invalid ingredient category");