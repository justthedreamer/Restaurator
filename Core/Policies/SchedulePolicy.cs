using Core.Model.ScheduleModel;
using Core.Policies.Abstraction;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Core.Policies;

/// <summary>
/// Schedule policy implementation
/// </summary>
internal class SchedulePolicy : ISchedulePolicy
{
    /// <summary>
    /// Available roles to add employee schedule
    /// </summary>
    private static readonly UserRole[] PermittedRoles = [UserRole.Owner, UserRole.Manager];

    /// <summary>
    /// Max work time span in hours
    /// </summary>
    private const ushort MaxWorkHours = 12;

    /// <summary>
    /// Check if request user is in permitted role.
    /// </summary>
    /// <param name="userRole"></param>
    /// <returns>True: Correct user role. False : Incorrect user role.</returns>
    public bool IsInRole(UserRole userRole) => PermittedRoles.Any(x => x == userRole);

    /// <summary>
    /// Check if employee schedule could be added to daily employee schedule.
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeSchedule">Employee schedule</param>
    /// <returns>True : Can apply. False : Can't apply.</returns>
    public bool CanApply(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeSchedule employeeSchedule)
    {
        if (EmployeeScheduleAlreadyExists(dailyEmployeeSchedule, employeeSchedule)) return false;
        return true;
    }


    /// <summary>
    /// Check if new dates could be changed in daily employee context.
    /// </summary>
    /// <param name="from">New date from</param>
    /// <param name="to">New date to</param>
    /// <returns>True or false</returns>
    public bool CanChangeDate(EmployeeScheduleDate from, EmployeeScheduleDate to) =>
        IsScheduleTimeSpanCorrect(from, to);

    /// <summary>
    /// Get maximum work hours.
    /// </summary>
    /// <returns>Maximum work time span in hours</returns>
    public ushort GetMaxWorkHours() => MaxWorkHours;

    /// <summary>
    /// Check if schedule time span is correct.
    /// </summary>
    /// <param name="from">Date from</param>
    /// <param name="to">Date to</param>
    /// <returns>True or false</returns>
    private bool IsScheduleTimeSpanCorrect(EmployeeScheduleDate from, EmployeeScheduleDate to)
    {
        var duration = new TimeSpan(to.Value.Ticks - from.Value.Ticks).Duration();
        return from.Value < to.Value && duration.Hours <= MaxWorkHours;
    }

    /// <summary>
    /// Check if employee schedule already exists.
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="newEmployeeSchedule">New employee schedule</param>
    /// <returns>True or false</returns>
    private bool EmployeeScheduleAlreadyExists(DailyEmployeeSchedule dailyEmployeeSchedule,
        EmployeeSchedule newEmployeeSchedule) =>
        dailyEmployeeSchedule.EmployeeSchedules.Any(x =>
            x.Employee.UserId == newEmployeeSchedule.Employee.UserId);
}