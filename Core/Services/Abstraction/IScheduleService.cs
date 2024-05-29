using Core.Model.ScheduleModel;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Core.Services.Abstraction;

/// <summary>
/// Employee schedule service interface
/// </summary>
public interface IScheduleService
{
    /// <summary>
    /// Add new schedule
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeSchedule">New employee schedule</param>
    /// <param name="userRole">Request user role</param>
    void AddSchedule(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeSchedule employeeSchedule, UserRole userRole);

    /// <summary>
    /// Remove employee schedule
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Daily employee schedule</param>
    /// <param name="userRole">Request user role</param>
    void RemoveSchedule(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        UserRole userRole);

    /// <summary>
    /// Change schedule date
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Employee schedule ID</param>
    /// <param name="from">Start work date</param>
    /// <param name="to">End work date</param>
    /// <param name="userRole">Request user role</param>
    void ChangeScheduleDate(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        EmployeeScheduleDate from, EmployeeScheduleDate to, UserRole userRole);

    /// <summary>
    /// Change schedule state
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Employee Schedule ID</param>
    /// <param name="scheduleState">Schedule state</param>
    /// <param name="userRole">Request user role</param>
    void ChangeScheduleState(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        ScheduleState scheduleState, UserRole userRole);
}