using System.Runtime.CompilerServices;
using Core.Exceptions.Policies;
using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.Services.Abstraction;
using Core.ValueObject.Reservation;
using Core.ValueObject.Staff.Employee;



namespace Core.Services;

/// <summary>
/// Reservation service implementation
/// </summary>
internal class ReservationService : IReservationService
{
    /// <summary>
    /// Change reservation table
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="table"></param>
    public void ChangeTable( Reservation reservation, Table table)
    {
        reservation.ChangeTable(table);
    }

    /// <summary>
    /// Change customer name
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="firstName">New first name</param>
    /// <param name="lastName">New last name</param>
    public void ChangeCustomerName(Reservation reservation, FirstName firstName, LastName lastName) =>
        reservation.ChangeCustomerName(firstName, lastName);

    /// <summary>
    /// Change reservation date
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="reservationDate">New reservation date</param>
    /// <param name="reservationTime">New reservation time</param>
    public void ChangeReservationDate(Reservation reservation, ReservationDate reservationDate,
        ReservationTime reservationTime) => reservation.ChangeReservationDate(reservationDate, reservationTime);

    /// <summary>
    /// Change customer count
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="customerCount">New customer count</param>
    public void ChangeCustomerCount(Reservation reservation, CustomerCount customerCount) =>
        reservation.ChangeCustomerCount(customerCount);
}