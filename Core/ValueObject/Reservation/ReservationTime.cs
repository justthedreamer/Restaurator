using Core.Exceptions.Reservation;

namespace Core.ValueObject.Reservation;

/// <summary>
/// Represents customer reservation time in hours.
/// </summary>
public sealed record ReservationTime
{
    public ushort Value { get; }

    public ReservationTime(ushort value)
    {
        if (value <= 0)
        {
            throw new InvalidReservationTimeException();
        }
        
        Value = value;
    }

    public static implicit operator ReservationTime(ushort value) => new(value);
    public static implicit operator ushort(ReservationTime reservationTime) => reservationTime.Value;
}