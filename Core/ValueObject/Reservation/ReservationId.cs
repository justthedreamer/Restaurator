namespace Core.ValueObject.Reservation;

public sealed record ReservationId
{
    public Guid Value { get; }

    public ReservationId(Guid value)
    {
        Value = value;
    }

    public static implicit operator ReservationId(Guid value) => new(value);
    public static implicit operator Guid(ReservationId reservationId) => reservationId.Value;
}