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

public class MenuItemServiceSuccessScenarioTests
{
    [Theory]
    [InlineData("Food")]
    [InlineData("Fruits")]
    [InlineData("Meet")]
    public void update_menu_item_category_with_correct_data_category_should_change(MenuItemCategory menuItemCategory)
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        //Act
        _menuItemService.UpdateMenuItemCategory(menuItem, menuItemCategory, UserRole.Owner);
        //Asser
        menuItem.Category.Value.ShouldBe(menuItemCategory);
    }

    [Fact]
    public void change_menu_item_price_with_correct_data_category_should_change()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newPrice = new Price(200);
        //Act
        _menuItemService.ChangeMenuItemPrice(menuItem, newPrice, UserRole.Owner);
        //Asser
        menuItem.RetailPrice.Value.ShouldBe(newPrice.Value);
    }

    [Fact]
    public void add_ingredient_to_menu_item_list_should_contain_new_element()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var ingredient = new Ingredient(Guid.NewGuid(), "Cucumber", "Vegetables", 10);
        //Act
        _menuItemService.AddIngredient(menuItem,ingredient, UserRole.Owner);
        //Asser
        menuItem.Ingredients.ShouldContain(ingredient);
    }
    
    [Fact]
    public void remove_ingredient_ingredients_list_should_not_contain_previous_added_element()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var ingredient = new Ingredient(Guid.NewGuid(), "Cucumber", "Vegetables", 10);
        //Act
        _menuItemService.AddIngredient(menuItem,ingredient, UserRole.Owner);
        _menuItemService.RemoveIngredient(menuItem,ingredient, UserRole.Owner);
        //Asser
        menuItem.Ingredients.ShouldNotContain(ingredient);
    }

    [Fact]
    public void update_description_menu_item_description_should_be_equal_to_given_content()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newDescription = "New description";
        //Act
        _menuItemService.UpdateMenuItemDescription(menuItem,newDescription,UserRole.Owner);
        //Asser
        menuItem.Description.ShouldNotBeNull();
        menuItem.Description.Value.ShouldBe(newDescription);
    }

    [Fact]
    public void remove_description_menu_item_description_should_me_null()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        //Act
        _menuItemService.RemoveMenuItemDescription(menuItem,UserRole.Owner);
        //Asser
        menuItem.Description.ShouldBeNull();
    }

    [Fact]
    public void update_prepare_time_menu_item_prepare_time_should_changed()
    {
     
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        var newPrepareTime = new PrepareTime("20 min");
        //Act
        _menuItemService.UpdatePrepareTime(menuItem,newPrepareTime,UserRole.Owner);
        //Asser
        menuItem.PrepareTime.ShouldNotBeNull();
        menuItem.PrepareTime.Value.ShouldBe(newPrepareTime.Value);
    }

    [Fact]
    public void remove_prepare_time_menu_item_prepare_time_should_be_null()
    {
        //Arrange
        var menuItem = MenuItemFactory.CreateMenuItem();
        //Act
        _menuItemService.RemovePrepareTime(menuItem,UserRole.Owner);
        //Asser
        menuItem.PrepareTime.ShouldBeNull();
    }

    private readonly IMenuItemService _menuItemService = new Core.Services.MenuItemService(new MenuItemPolicy());
}