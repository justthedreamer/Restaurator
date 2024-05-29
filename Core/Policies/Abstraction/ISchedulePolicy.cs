using Core.Model.ScheduleModel;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Core.Policies.Abstraction;

/// <summary>
/// Schedule policy interface
/// </summary>
internal interface ISchedulePolicy
{
    /// <summary>
    /// Check if request user is permitted to manage schedules.
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns>True or false</returns>
    bool IsInRole(UserRole userRole);

    /// <summary>
    /// Check if employee schedule could be added to daily employee schedule.
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeSchedule">Employee schedule</param>
    /// <returns>True or false</returns>
    bool CanApply(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeSchedule employeeSchedule);

    /// <summary>
    /// Check if new dates could be changed in daily employee context.
    /// </summary>
    /// <param name="from">New date from</param>
    /// <param name="to">New date to</param>
    /// <returns>True or false</returns>
    bool CanChangeDate(EmployeeScheduleDate from, EmployeeScheduleDate to);

    /// <summary>
    /// Get max work hours
    /// </summary>
    /// <returns>Max work hours</returns>
    ushort GetMaxWorkHours();
}