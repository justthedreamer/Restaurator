using Core.Exceptions.Policies;
using Core.Exceptions.PromoCode;
using Core.Model.OrderModel;
using Core.Policies;
using Core.Services.Abstraction;
using Core.ValueObject.PromoCode;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.PromoCodeService;

public class PromoCodeServiceFailScenario
{
    [Fact]
    public void change_promo_code_value_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        // Arrange
        var promoCode = PromoCodeFactory.CreateDayOfWeekPromoCode();
        var promoCodeValue = new PromoCodeValue(100);
        var userRole = UserRole.Employee;

        //Act,Asser
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _promoCodeService.ChangePromoCodeValue(promoCode, promoCodeValue, userRole, new List<Order>());
        });
    }

    [Fact]
    public void
        change_promo_code_value_when_promo_code_has_been_used_in_restaurant_order_history_should_throw_promo_code_has_been_used_exception()
    {
        // Arrange
        var order = OrderFactory.CreateRestaurantOrder();
        var promoCode = PromoCodeFactory.CreateDayOfWeekPromoCode();
        order.AddOrderPromoCode(promoCode);
        var promoCodeValue = new PromoCodeValue(100);
        var userRole = UserRole.Manager;


        //Act,Asser
        Should.Throw<PromoCodeHasBeenUsedException>(() =>
        {
            _promoCodeService.ChangePromoCodeValue(promoCode, promoCodeValue, userRole,
                new List<Order>() { order });
        });
    }

    [Theory]
    [InlineData(PromoCodeValueType.Percentage, 101)]
    [InlineData(PromoCodeValueType.Percentage, 0)]
    [InlineData(PromoCodeValueType.Cash, 0)]
    public void change_promo_code_value_whit_invalid_value_should_throw_invalid_promo_code_value_exception(
        PromoCodeValueType valueType, ushort value)
    {
        // Arrange
        var order = OrderFactory.CreateRestaurantOrder();
        var promoCode = PromoCodeFactory.CreateDayOfWeekPromoCode(valueType);
        order.AddOrderPromoCode(promoCode);
        var userRole = UserRole.Manager;
        var orders = new List<Order>();


        //Act,Asser
        Should.Throw<InvalidPromoCodeValueException>(() =>
        {
            var promoCodeValue = new PromoCodeValue(value);
            _promoCodeService.ChangePromoCodeValue(promoCode, promoCodeValue, userRole, orders);
        });
    }

    [Fact]
    public void change_promo_code_state_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var promoCode = PromoCodeFactory.CreateDayOfWeekPromoCode();
        var state = PromoCodeState.UnActive;

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _promoCodeService.ChangePromoCodeState(promoCode, state, UserRole.Employee);
        });
    }

    [Fact]
    public void change_range_date_promo_code_dates_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var promoCode = PromoCodeFactory.CreateRangeDatePromoCode();
        var from = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        var to = from.AddDays(7);
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var orders = new List<Order>();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _promoCodeService.ChangeRangeDatePromoCodeDates(promoCode, from, to, currentDate, UserRole.Employee,
                orders);
        });
    }

    [Fact]
    public void
        change_range_date_promo_code_dates_when_promo_code_has_been_used_in_restaurant_order_history_should_throw_promo_code_has_been_used_exception()
    {
        var promoCode = PromoCodeFactory.CreateRangeDatePromoCode();
        var from = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        var to = from.AddDays(7);
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var order = OrderFactory.CreateRestaurantOrder();
        order.AddOrderPromoCode(promoCode);
        var orders = new List<Order>() { order };

        Should.Throw<PromoCodeHasBeenUsedException>(() =>
        {
            _promoCodeService.ChangeRangeDatePromoCodeDates(promoCode, from, to, currentDate, UserRole.Manager,
                orders);
        });
    }

    [Fact]
    public void
        change_range_date_promo_code_dates_with_incorrect_dates_should_throw_invalid_range_date_promo_code_dates_exception()
    {
        var promoCode = PromoCodeFactory.CreateRangeDatePromoCode();
        var from = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
        var to = from.AddDays(-7);
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var order = OrderFactory.CreateRestaurantOrder();
        order.AddOrderPromoCode(promoCode);
        var orders = new List<Order>();

        Should.Throw<InvalidRangeDatePromoCodeDatesException>(() =>
        {
            _promoCodeService.ChangeRangeDatePromoCodeDates(promoCode, from, to, currentDate, UserRole.Manager,
                orders);
        });
    }

    [Fact]
    public void
        change_specific_date_promo_code_date_with_not_permitted_role_should_throw_policy_no_permission_exception()
    {
        var promoCode = PromoCodeFactory.CreateSpecificDatePromoCode();
        var date = DateOnly.FromDateTime(new DateTime().AddDays(1));
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var orders = new List<Order>();

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _promoCodeService.ChangeSpecificDatePromoCodeDate(promoCode, date ,currentDate, UserRole.Employee,
                orders);
        });
    }

    [Fact]
    public void
        change_specific_date_promo_code_date_when_promo_code_has_been_used_in_restaurant_order_history_should_throw_promo_code_has_been_used_exception()
    {
        var promoCode = PromoCodeFactory.CreateSpecificDatePromoCode();
        var date = DateOnly.FromDateTime(new DateTime().AddDays(1));
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var order = OrderFactory.CreateRestaurantOrder();
        order.AddOrderPromoCode(promoCode);
        var orders = new List<Order>() { order };

        Should.Throw<PromoCodeHasBeenUsedException>(() =>
        {
            _promoCodeService.ChangeSpecificDatePromoCodeDate(promoCode, date, currentDate, UserRole.Manager, orders);
        });
    }

    [Fact]
    public void
        change_specific_date_promo_code_date_with_incorrect_date_should_throw_invalid_specific_date_promo_code_date_exception()
    {
        var promoCode = PromoCodeFactory.CreateSpecificDatePromoCode();
        var date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1));
        var currentDate = DateOnly.FromDateTime(DateTime.Now);
        var order = OrderFactory.CreateRestaurantOrder();
        order.AddOrderPromoCode(promoCode);
        var orders = new List<Order>();

        Should.Throw<InvalidSpecificDatePromoCodeDateException>(() =>
        {
            _promoCodeService.ChangeSpecificDatePromoCodeDate(promoCode, date, currentDate, UserRole.Manager, orders);
        });
    }

    private readonly IPromoCodeService _promoCodeService = new Core.Services.PromoCodeService(new PromoCodePolicy());
}