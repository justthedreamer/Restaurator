using Core.Exceptions.Policies;
using Core.Exceptions.Schedule;
using Core.Policies;
using Core.Services.Abstraction;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Services.ScheduleService;

public class ScheduleServiceFailScenarioTests
{
    [Fact]
    public void
        add_employee_schedule_when_other_schedule_of_this_employee_exists_should_throw_schedule_service_policy_exception()
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(10,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        
        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);

        var schedule2 =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1,
                scheduleDate.Item2);

        Should.Throw<ScheduleServicePolicyException>(() =>
        {
            _scheduleService.AddSchedule(dailyEmployeeSchedule,schedule2,UserRole.Owner);
        });
    }
    
    
    [Fact]
    public void add_schedule_with_incorrect_role_should_throw_policy_no_permission_exception()
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(10,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        

        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _scheduleService.AddSchedule(dailyEmployeeSchedule,employeeSchedule,UserRole.Employee);
        });
    }
    
    [Fact]
    public void
        remove_schedule_given_incorrect_employee_schedule_id_should_throw_employee_schedule_not_found_exception()
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(8,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        
        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);
        
        Should.Throw<EmployeeScheduleNotFountException>(() =>
        {
            _scheduleService.RemoveSchedule(dailyEmployeeSchedule,Guid.NewGuid(),UserRole.Owner);
        });
    }
    
    [Fact]
    public void
        remove_schedule_with_incorrect_role_should_throw_policy_no_permission_exception()
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(8,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        
        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);
        
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _scheduleService.RemoveSchedule(dailyEmployeeSchedule,employeeSchedule.EmployeeScheduleId,UserRole.Employee);
        });
    }

    
    [Theory]
    [InlineData(13)]
    [InlineData(14)]
    public void change_schedule_date_given_incorrect_schedule_time_span_should_throw_schedule_service_policy_exception(int timeSpan)
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(8,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        
        var dateToChange = DateFactory.CreateEmployeeScheduleDate(8,timeSpan);
        
        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);
        
        Should.Throw<ScheduleServicePolicyException>(() =>
        {
            _scheduleService.ChangeScheduleDate(dailyEmployeeSchedule,employeeSchedule.EmployeeScheduleId,dateToChange.Item1,dateToChange.Item2,UserRole.Owner);
        });
    }

    [Fact]
    public void change_schedule_state_given_incorrect_id_should_throw_employee_schedule_not_found_exception()
    {
        var dailyEmployeeScheduleId = Guid.NewGuid();
        var dailyEmployeeSchedule = ScheduleFactory.CreateDailyEmployeeSchedule(dailyEmployeeScheduleId);

        var employeeId = Guid.NewGuid();
        var employee = EmployeeFactory.CreateEmployeeWaiter(employeeId);
        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(8,8);
        
        var employeeSchedule =
            ScheduleFactory.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1, scheduleDate.Item2);
        
        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);
        
        Should.Throw<EmployeeScheduleNotFountException>(() =>
        {
            _scheduleService.ChangeScheduleState(dailyEmployeeSchedule,Guid.NewGuid(),ScheduleState.Confirmed,UserRole.Owner);
        });
    }
    
    [Fact]
    public void change_schedule_state_with_incorrect_role_should_throw_policy_no_permission_exception()
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
        Should.Throw<PolicyNoPermissionsException>(() =>
        {
            _scheduleService.ChangeScheduleState(dailyEmployeeSchedule, employeeScheduleId,ScheduleState.Confirmed,UserRole.Employee);
        });
    }
    
    private readonly IScheduleService _scheduleService = new Core.Services.ScheduleService(new SchedulePolicy());
}