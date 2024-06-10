using Application.Commands.Abstraction;

namespace Application.Commands;

public record CreateDailySchedule : ICommand
{
    public Guid ScheduleId { get; init; }
    public Guid RestaurantId { get; init; }
    public Guid UserId { get; init; }
    public DateOnly Date { get; init; }
}