using Application.Commands.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Commands;

public record CreateEmployeeSchedule : ICommand
{
    public Guid RestaurantId { get; init; }
    public Guid DailyEmployeeScheduleId { get; init; }
    public Guid ScheduleId { get; init; }
    public Guid EmployeeId { get; set; }
    public Guid RequestingUserId { get; set; }
    public TimeOnly From { get; init; }
    public TimeOnly To { get; init; }
}