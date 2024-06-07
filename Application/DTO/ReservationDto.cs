using Core.ValueObject.Reservation;
using Core.ValueObject.Restaurant;
using Core.ValueObject.Staff.Employee;

namespace Application.DTO;

public sealed class ReservationDto
{
    public required ReservationId Id { get; init; }
    public required TableSign TableSign { get; init; }
    public required FirstName CustomerFirstName { get; init; }
    public required LastName CustomerLastName { get; init; }
    public required ReservationDate ReservationDate { get; init; }
    public required ReservationTime ReservationTime { get; init; }
    public required CustomerCount CustomerCount { get; init; }
}