namespace Core.ValueObject.Reservation;

public sealed record ReservationDate
{
    public DateTime Value { get; }

    public ReservationDate(DateTime value)
    {
        Value = value;
    }

    public static implicit operator ReservationDate(DateTime value) => new(value);
    public static implicit operator DateTime(ReservationDate reservationDate) => reservationDate.Value;
}