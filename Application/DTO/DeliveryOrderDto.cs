using Application.DTO.User;
using Core.Model.AddressModel;
using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;

namespace Application.DTO;

public sealed class DeliveryOrderDto : OrderDto
{
    public required FirstName CustomerFirstName { get; init; }
    public required LastName CustomerLastName { get; init; }
    public required Address CustomerAddress { get; init; }
    public required PhoneNumber CustomerPhoneNumber { get; init; }
    public CourierDto? Courier { get; init; }
}