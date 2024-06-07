using Core.ValueObject.Staff.Employee;

namespace Application.DTO;

public class TakeAwayOrderDto : OrderDto
{
    public required FirstName CustomerFirstName { get; init; }
    public required LastName CustomerLastName { get; init; }
}