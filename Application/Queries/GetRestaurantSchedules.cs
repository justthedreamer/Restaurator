using Application.DTO;
using Application.DTO.User;
using Application.Queries.Abstraction;

namespace Application.Queries;

public sealed class GetRestaurantSchedules : IQuery<IEnumerable<DailyEmployeeScheduleDto>>
{
    public Guid RestaurantId { get; init; }
    public DateOnly From { get; init; }
    public DateOnly To { get; init; }
}