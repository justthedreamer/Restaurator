using Application.DTO.User;
using Core.Model.AddressModel;
using Core.Model.StaffModel;
using Core.ValueObject.Common;
using Core.ValueObject.Staff.Employee;

namespace Application.DTO;

public sealed class DeliveryOrderDto : OrderDto
{
    public required string CustomerFirstName { get; init; }
    public required string CustomerLastName { get; init; }
    public required string CustomerPhoneNumber { get; init; }
    public string? CourierPhoneNumber { get; init; }
    public required AddressDto CustomerAddress { get; init; }
}

