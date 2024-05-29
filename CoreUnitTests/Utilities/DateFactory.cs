using Core.ValueObject.Schedule;

namespace CoreUnitTests.Utilities;

public static class DateFactory
{

    /// <summary>
    /// Create tuple of employee schedule date.
    /// </summary>
    /// <param name="startHour">Start hour</param>
    /// <param name="timeSnap">Hours time snap</param>
    /// <returns></returns>
    public static (EmployeeScheduleDate, EmployeeScheduleDate) CreateEmployeeScheduleDate(int startHour, int timeSnap)
    {

        var start = new TimeOnly(startHour,0,0);
        var end = start.AddHours(timeSnap);
        
        return (start, end);
    }
}