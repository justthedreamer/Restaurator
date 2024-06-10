namespace Application.DTO;

public class DailyEmployeeScheduleDto
{
    public Guid Id { get; set; }
    public IEnumerable<EmployeeScheduleDto> EmployeeSchedules { get; set; }
}