using Core.Exceptions.Policies;
using Core.Model.MenuModel;
using Core.Policies;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Menu;
using Core.ValueObject.Price;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.MenuItemService;

public class MenuItemServiceFailScenarioTests
{
    [Theory]
    [InlineData(UserRole.Employee)]
    public void update_menu_item_category_with_incorrect_role_should_throw_policy_no_permission_exception(
        UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var menuItemCategory = new MenuItemCategory("category");

        //Act,Assert
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.UpdateMenuItemCategory(menuItem, menuItemCategory, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void change_menu_item_price_with_incorrect_role_should_throw_policy_no_permission_exception(
        UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newPrice = new Price(200);

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.ChangeMenuItemPrice(menuItem, newPrice, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void add_ingredient_with_incorrect_role_should_throw_policy_no_permission_exception(UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var ingredient = new Ingredient(Guid.NewGuid(), "Cucumber", "Vegetables", 10);

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.AddIngredient(menuItem, ingredient, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void remove_ingredient_with_incorrect_role_should_throw_policy_no_permission_exception(UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var ingredient = new Ingredient(Guid.NewGuid(), "Cucumber", "Vegetables", 10);

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.RemoveIngredient(menuItem, ingredient, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void update_description_with_incorrect_role_should_throw_policy_no_permission_exception(UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newDescription = "New description";

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.UpdateMenuItemDescription(menuItem, newDescription, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void remove_description_with_incorrect_role_should_throw_policy_no_permission_exception(UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.RemoveMenuItemDescription(menuItem, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void update_prepare_time_with_incorrect_role_should_throw_policy_no_permission_exception(
        UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newPrepareTime = new PrepareTime("20 min");

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.UpdatePrepareTime(menuItem, newPrepareTime, userRole);
        });
    }

    [Theory]
    [InlineData(UserRole.Employee)]
    public void remove_prepare_time_with_incorrect_role_should_throw_policy_no_permission_exception(UserRole userRole)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();

        //Act
        //Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _menuItemService.RemovePrepareTime(menuItem, userRole);
        });
    }

    private readonly IMenuItemService _menuItemService = new Core.Services.MenuItemService(new MenuItemPolicy());
}