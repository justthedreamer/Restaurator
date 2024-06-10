using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public record GetDailySchedule : IQuery<DailyEmployeeScheduleDto>
{
    public Guid RestaurantId { get; init; }
    public Guid ScheduleId { get; init; }
}