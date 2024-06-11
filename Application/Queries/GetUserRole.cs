using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Queries;

public sealed record GetUserRole : IQuery<UserRole>
{
    public required Guid UserId { get; set; }
}