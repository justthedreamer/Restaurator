using Core.Exceptions.Policies;
using Core.Exceptions.Schedule;
using Core.Model.ScheduleModel;
using Core.Policies.Abstraction;
using Core.Services.Abstraction;
using Core.ValueObject.Schedule;
using Core.ValueObject.Staff.User;

namespace Core.Services;

/// <summary>
/// Schedule service implementation
/// </summary>
/// <param name="policy">Instance of <see cref="ISchedulePolicy"/></param>
internal class ScheduleService(ISchedulePolicy policy) : IScheduleService
{
    /// <summary>
    /// Add new employee schedule to daily schedule list.
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeSchedule">New employee schedule</param>
    /// <param name="userRole">Request user role</param>
    public void AddSchedule(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeSchedule employeeSchedule,
        UserRole userRole)
    {
        var isInRole = policy.IsInRole(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        var canApply = policy.CanApply(dailyEmployeeSchedule, employeeSchedule);

        if (!canApply)
        {
            throw new ScheduleServicePolicyException(
                "Business Critical Error : Cannot apply schedule.\nOther schedule may already exists in the same date or schedule time snap is incorrect.");
        }

        dailyEmployeeSchedule.AddEmployeeSchedule(employeeSchedule);
    }

    /// <summary>
    /// Remove employee schedule from daily schedule list.
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Daily employee schedule</param>
    /// <param name="userRole">Request user role</param>
    public void RemoveSchedule(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        UserRole userRole)
    {
        var isInRole = policy.IsInRole(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        var employeeSchedule =
            dailyEmployeeSchedule.EmployeeSchedules.SingleOrDefault(x => x.EmployeeScheduleId == employeeScheduleId);

        if (employeeSchedule is null)
        {
            throw new EmployeeScheduleNotFountException(employeeScheduleId);
        }

        dailyEmployeeSchedule.RemoveEmployeeSchedule(employeeSchedule);
    }

    /// <summary>
    /// Change employee schedule schedule date
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Employee schedule ID</param>
    /// <param name="from">Start work date</param>
    /// <param name="to">End work date</param>
    /// <param name="userRole">Request user role</param>
    public void ChangeScheduleDate(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        EmployeeScheduleDate from, EmployeeScheduleDate to, UserRole userRole)
    {
        var isInRole = policy.IsInRole(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        var employeeSchedule =
            dailyEmployeeSchedule.EmployeeSchedules.SingleOrDefault(x => x.EmployeeScheduleId == employeeScheduleId);

        if (employeeSchedule is null)
            throw new EmployeeScheduleNotFountException(employeeScheduleId);

        var canChangeDate = policy.CanChangeDate(from, to);

        if (!canChangeDate)
        {
            throw new ScheduleServicePolicyException(
                "Business Critical Error : Cannot change date of employee schedule.\nSchedule time snap could me incorrect or provided dates not match the daily employee schedule date.");
        }

        employeeSchedule.ChangeScheduleDate(from, to);
    }

    /// <summary>
    /// Change schedule state
    /// </summary>
    /// <param name="dailyEmployeeSchedule">Daily employee schedule</param>
    /// <param name="employeeScheduleId">Employee Schedule ID</param>
    /// <param name="scheduleState">Schedule state</param>
    /// <param name="userRole">Request user role</param>
    public void ChangeScheduleState(DailyEmployeeSchedule dailyEmployeeSchedule, EmployeeScheduleId employeeScheduleId,
        ScheduleState scheduleState, UserRole userRole)
    {
        var isInRole = policy.IsInRole(userRole);

        if (!isInRole)
            throw new PolicyNoPermissionsException();

        var employeeSchedule =
            dailyEmployeeSchedule.EmployeeSchedules.SingleOrDefault(x => x.EmployeeScheduleId == employeeScheduleId);

        if (employeeSchedule is null)
        {
            throw new EmployeeScheduleNotFountException(employeeScheduleId);
        }

        employeeSchedule.ChangeScheduleState(scheduleState);
    }
}