using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public sealed record GetOwnerProfileQuery(Guid OwnerId) : IQuery<OwnerProfileDto>;
