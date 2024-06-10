using Core.Model.ScheduleModel;
using Core.Model.StaffModel;
using Core.ValueObject.Schedule;

namespace CoreUnitTests.Utilities;

public static class ScheduleFactory
{
    /// <summary>
    /// Create list of employee schedule with one schedule sets on current day and 8h time stamp.
    /// </summary>
    /// <returns>List of employee schedule.</returns>
    public static List<EmployeeSchedule> CreateEmployeeScheduleList()
    {
        var date1 = DateFactory.CreateEmployeeScheduleDate(10, 8);
        var employee1 = EmployeeFactory.CreateEmployeeWaiter(Guid.NewGuid());
        var schedule1 = EmployeeSchedule.CreateEmployeeSchedule(Guid.NewGuid(), employee1, date1.Item1, date1.Item2,ScheduleState.WaitingForApproval);

        return new List<EmployeeSchedule>() { schedule1 };
    }
    
    /// <summary>
    /// Create daily employee schedule on current date, with empty employee schedule list.
    /// </summary>
    /// <returns></returns>
    public static DailyEmployeeSchedule CreateDailyEmployeeSchedule()
    {
        var id = Guid.NewGuid();
        var currentDate = DateTime.Now;
        var scheduleDate = new DailyScheduleDate(DateOnly.FromDateTime(currentDate));

        return new DailyEmployeeSchedule(id, scheduleDate);
    }
    
    
    /// <summary>
    /// Create daily employee schedule on current date, with empty employee schedule list.
    /// </summary>
    /// <param name="dailyEmployeeScheduleId">Unique ID</param>
    /// <returns></returns>
    public static DailyEmployeeSchedule CreateDailyEmployeeSchedule(DailyEmployeeScheduleId dailyEmployeeScheduleId)
    {
        var id = dailyEmployeeScheduleId;
        var currentDate = DateTime.Now;
        var scheduleDate = new DailyScheduleDate(DateOnly.FromDateTime(currentDate));

        return new DailyEmployeeSchedule(id, scheduleDate);
    }

    /// <summary>
    /// Create employee schedule on current date.
    /// </summary>
    /// <param name="employeeScheduleId"></param>
    /// <param name="employee"></param>
    /// <param name="from">from</param>
    /// <param name="to">to</param>
    /// <returns></returns>
    public static EmployeeSchedule CreateEmployeeSchedule(EmployeeScheduleId employeeScheduleId,Employee employee,EmployeeScheduleDate from, EmployeeScheduleDate to)
    {
        const string state = ScheduleState.WaitingForApproval;
        return EmployeeSchedule.CreateEmployeeSchedule(employeeScheduleId, employee, from,to,state);
    }
}