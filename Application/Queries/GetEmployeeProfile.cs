using Application.DTO.User;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Queries;

public sealed record GetEmployeeProfile : IQuery<EmployeeDto>
{
    public required Guid RestaurantId { get; init; }
    public required Guid EmployeeId { get; init; }
}
