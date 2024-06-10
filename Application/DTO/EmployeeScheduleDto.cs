namespace Application.DTO;

public sealed record EmployeeScheduleDto
{
    public Guid EmployeeScheduleId { get; init; }
    public Guid EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public TimeOnly From { get; init; }
    public TimeOnly To { get; init; }
}