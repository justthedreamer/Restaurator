using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.ValueObject.Reservation;

namespace CoreUnitTests.Utilities;

public static class ReservationFactory
{
    public static Reservation CreateReservation(Table table)
    {
        var id = Guid.NewGuid();
        var firstName = "John";
        var lastName = "Doe";
        var reservationDate = DateTime.Now;
        ushort reservationTime = 5;
        ushort customerCount = 2;
        return new Reservation(id, table, firstName, lastName, reservationDate, reservationTime, customerCount);
    }
}