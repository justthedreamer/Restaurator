using Core.Model.ScheduleModel;
using Core.Policies;
using Core.Policies.Abstraction;
using Core.ValueObject.Schedule;
using CoreUnitTests.Utilities;
using Shouldly;

namespace CoreUnitTests.Policies;

public class SchedulePolicyTests
{
    [Fact]
    public void add_new_schedule_when_other_schedule_already_exists_canApply_method__should_return_false()
    {
        //Arrange
        var currentDate = DateTime.Now;
        var employee1 = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());

        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(10, 8);
        var scheduleDate2 = DateFactory.CreateEmployeeScheduleDate(10, 8);

        var schedule1 = EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), employee1, scheduleDate.Item1,
            scheduleDate.Item2,
            ScheduleState.WaitingForApproval);

        var schedule2 = EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), employee1, scheduleDate2.Item1,
            scheduleDate2.Item2,
            ScheduleState.WaitingForApproval);

        var dailyId = Guid.NewGuid();
        var dailyDate = new DailyScheduleDate(DateOnly.FromDateTime(currentDate));
        var scheduleList = new List<EmployeeSchedule>() { schedule1 };
        var dailyEmployeeSchedule = new DailyEmployeeSchedule(dailyId, dailyDate);

        //Act
        var result = _schedulePolicy.CanApply(dailyEmployeeSchedule, schedule2);

        //Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void change_date_with_wrong_time_stamp_canChangeDate_method_should_return_false()
    {
        //Arrange
        var currentDate = DateTime.Now;
        var employee = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());


        var scheduleDate = DateFactory.CreateEmployeeScheduleDate(10, 8);
        var dateToChange = DateFactory.CreateEmployeeScheduleDate(10, 18);

        var schedule = EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), employee, scheduleDate.Item1,
            scheduleDate.Item2,
            ScheduleState.WaitingForApproval);

        var dailyId = Guid.NewGuid();
        var dailyDate = new DailyScheduleDate(DateOnly.FromDateTime(currentDate));
        var scheduleList = new List<EmployeeSchedule>() { schedule };
        var dailyEmployeeSchedule = new DailyEmployeeSchedule(dailyId, dailyDate);

        //Act
        var result = _schedulePolicy.CanChangeDate(dateToChange.Item1, dateToChange.Item2);
        //Assert
        result.ShouldBeFalse();
    }

    private readonly ISchedulePolicy _schedulePolicy = new SchedulePolicy();
}