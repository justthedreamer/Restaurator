using Application.DTO;
using Application.Queries.Abstraction;

namespace Application.Queries;

public record GetRestaurantTables : IQuery<IEnumerable<TableDto>>
{
    public Guid RestaurantId { get; set; }
}