using Core.Utilities;
using Core.ValueObject.Schedule;

namespace Core.Model.ScheduleModel;

/// <summary>
/// Represent daily employee schedule
/// </summary>
public class DailyEmployeeSchedule
{
    public DailyEmployeeScheduleId DailyEmployeeScheduleId { get; private set; }
    public DailyScheduleDate DailyScheduleDate { get; private set; }
    public IReadOnlyList<EmployeeSchedule> EmployeeSchedules { get; private set; } = new List<EmployeeSchedule>();

    /// <summary>
    /// Add new schedule to list.
    /// </summary>
    /// <param name="employeeSchedule">New employee schedule.</param>
    internal void AddEmployeeSchedule(EmployeeSchedule employeeSchedule) =>
        EmployeeSchedules = EmployeeSchedules.AddItem(employeeSchedule);

    /// <summary>
    /// Remove employee schedule
    /// </summary>
    /// <param name="employeeSchedule">Employee schedule do remove</param>
    internal void RemoveEmployeeSchedule(EmployeeSchedule employeeSchedule) =>
        EmployeeSchedules = EmployeeSchedules.RemoveItem(employeeSchedule);

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private DailyEmployeeSchedule()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="dailyEmployeeScheduleId"></param>
    /// <param name="dailyScheduleDate"></param>
    public DailyEmployeeSchedule(DailyEmployeeScheduleId dailyEmployeeScheduleId, DailyScheduleDate dailyScheduleDate)
    {
        DailyEmployeeScheduleId = dailyEmployeeScheduleId;
        DailyScheduleDate = dailyScheduleDate.Value;
    }
}