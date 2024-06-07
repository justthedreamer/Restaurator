using Application.DTO.User;
using Application.Queries.Abstraction;
using Core.ValueObject.Staff.User;

namespace Application.Queries;

public sealed record GetEmployeeProfile(Guid EmployeeId) : IQuery<EmployeeDto>{}
