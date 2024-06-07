using Application.DTO.User;
using Application.Queries.Abstraction;
using Core.Model.StaffModel;
using Core.ValueObject.Restaurant;

namespace Application.Queries;

public sealed record GetRestaurantEmployees(Guid RestaurantId) : IQuery<IEnumerable<EmployeeDto>>{}
