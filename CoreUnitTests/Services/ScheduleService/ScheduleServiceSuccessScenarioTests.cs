using Core.Policies;
using Core.Services.Abstraction;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.ScheduleService;

public class ScheduleServiceSuccessScenarioTests
{
    [Fact]
    public void add_schedule_with_correct_data_should_not_throw_exception()
    {
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(Guid.NewGuid());

        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());
        var dates = DateFactory.CreateEmployeeScheduleDate(10,8);

        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, dates.Item1, dates.Item2);

        Should.NotThrow(() => { _scheduleService.AddSchedule(dailyEmployeeSchedule, employeeSchedule,UserRole.Owner); });
    }

    [Fact]
    public void remove_schedule_with_correct_data_should_not_throw_exception()
    {
        //Arrange
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(Guid.NewGuid());

        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());
        var dates = DateFactory.CreateEmployeeScheduleDate(8,10);

        var employeeScheduleId = Guid.NewGuid();
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(employeeScheduleId, employee, dates.Item1, dates.Item2);

        _scheduleService.AddSchedule(dailyEmployeeSchedule, employeeSchedule,UserRole.Owner);

        //Assert
        Should.NotThrow(() => { _scheduleService.RemoveSchedule(dailyEmployeeSchedule, employeeScheduleId,UserRole.Owner); });
    }

    [Fact]
    public void change_schedule_date_with_correct_data_should_not_throw_exception()
    {
        //Arrange
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(Guid.NewGuid());

        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());
        
        var scheduleDates = DateFactory.CreateEmployeeScheduleDate(10,8);

        var datesToChange = DateFactory.CreateEmployeeScheduleDate(10,12);

        var employeeScheduleId = Guid.NewGuid();
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(employeeScheduleId, employee, scheduleDates.Item1, scheduleDates.Item2);

        _scheduleService.AddSchedule(dailyEmployeeSchedule, employeeSchedule,UserRole.Owner);

        //Act, Assert
        Should.NotThrow(() =>
        {
            _scheduleService.ChangeScheduleDate(dailyEmployeeSchedule, employeeScheduleId,datesToChange.Item1,datesToChange.Item2,UserRole.Owner);
        });
    }

    [Fact]
    public void change_schedule_state_with_correct_data_should_not_throw_exception()
    {
        //Arrange
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(Guid.NewGuid());

        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());
        
        var scheduleDates = DateFactory.CreateEmployeeScheduleDate(10,8);

        var employeeScheduleId = Guid.NewGuid();
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(employeeScheduleId, employee, scheduleDates.Item1, scheduleDates.Item2);

        _scheduleService.AddSchedule(dailyEmployeeSchedule, employeeSchedule,UserRole.Owner);

        //Act, Assert
        Should.NotThrow(() =>
        {
            _scheduleService.ChangeScheduleState(dailyEmployeeSchedule, employeeScheduleId,ScheduleState.Confirmed,UserRole.Owner);
        });
    }
    
    private IScheduleService _scheduleService;

    public ScheduleServiceSuccessScenarioTests()
    {
        _scheduleService = new Core.Services.ScheduleService(new SchedulePolicy());
    }
}