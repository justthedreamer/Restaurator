using Core.Exceptions.Schedule;
using Core.Model.StaffModel;
using Core.ValueObject.Schedule;

namespace Core.Model.ScheduleModel;

/// <summary>
/// Represents Employee schedule.
/// </summary>
public class EmployeeSchedule
{
    public EmployeeScheduleId EmployeeScheduleId { get; private set; }
    public ScheduleState ScheduleState { get; private set; }
    public Employee Employee { get; private set; }
    public EmployeeScheduleDate From { get; private set; }
    public EmployeeScheduleDate To { get; private set; }
    public TotalWorkHours TotalWorkHours => CalculateTotalWorkHours();

    /// <summary>
    /// Change schedule date
    /// </summary>
    /// <param name="from">from</param>
    /// <param name="to">to</param>
    internal void ChangeScheduleDate(EmployeeScheduleDate from, EmployeeScheduleDate to)
    {
        From = from;
        To = to;
    }

    /// <summary>
    /// Change schedule stata
    /// </summary>
    /// <param name="scheduleState">New schedule state</param>
    internal void ChangeScheduleState(ScheduleState scheduleState) => ScheduleState = scheduleState;

    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private EmployeeSchedule()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="employeeScheduleId"></param>
    /// <param name="employee"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="scheduleState"></param>
    /// <exception cref="InvalidEmployeeScheduleTimeSpanException"></exception>
    private EmployeeSchedule(EmployeeScheduleId employeeScheduleId, Employee employee, EmployeeScheduleDate from,
        EmployeeScheduleDate to, ScheduleState scheduleState)
    {
        if (!IsValid(from, to))
        {
            throw new InvalidEmployeeScheduleTimeSpanException(from, to);
        }

        EmployeeScheduleId = employeeScheduleId;
        Employee = employee;
        From = from;
        To = to;
        ScheduleState = scheduleState;
    }

    
    /// <summary>
    /// Factory method
    /// </summary>
    /// <param name="employeeScheduleId">ID</param>
    /// <param name="employee">Employee</param>
    /// <param name="from">Work starting date</param>
    /// <param name="to">Work ending date</param>
    /// <param name="scheduleState">Schedule state</param>
    /// <returns>New instance of <see cref="EmployeeSchedule"/>></returns>
    /// <exception cref="InvalidEmployeeScheduleTimeSpanException">If time span between provided dates is incorrect.</exception>
    public static EmployeeSchedule CreateEmployeeSchedule(EmployeeScheduleId employeeScheduleId, Employee employee,
        EmployeeScheduleDate from, EmployeeScheduleDate to, ScheduleState scheduleState)
    {
        if (from.Value > to.Value)
            throw new InvalidEmployeeScheduleTimeSpanException(from, to);

        return new EmployeeSchedule(employeeScheduleId, employee, from, to, scheduleState);
    }


    /// <summary>
    /// Validate provided parameters.
    /// </summary>
    /// <param name="from">Start work date.</param>
    /// <param name="to">End work date.</param>
    /// <returns></returns>
    private bool IsValid(EmployeeScheduleDate from, EmployeeScheduleDate to)
    {
        return from.Value < to.Value;
    }

    /// <summary>
    /// Calculates total work hours.
    /// </summary>
    /// <returns></returns>
    private TotalWorkHours CalculateTotalWorkHours()
    {
        var startingHour = From.Value.Hour;
        var endingHour = To.Value.Hour;

        int hoursElapsed = endingHour >= startingHour
            ? endingHour - startingHour
            : (24 - startingHour + endingHour) % 24;

        return hoursElapsed;
    }
}