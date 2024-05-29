using Core.Model.ReservationModel;
using Core.Model.RestaurantModel;
using Core.ValueObject.Reservation;
using Core.ValueObject.Staff.Employee;

namespace Core.Services.Abstraction;

/// <summary>
/// Reservation service interface
/// </summary>
public interface IReservationService
{
    /// <summary>
    /// Change reservation table
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="table"></param>
    void ChangeTable(Reservation reservation, Table table);
    
    /// <summary>
    /// Change customer name
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="firstName">New first name</param>
    /// <param name="lastName">New last name</param>
    void ChangeCustomerName(Reservation reservation, FirstName firstName, LastName lastName);
    
    /// <summary>
    /// Change reservation date
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="reservationDate">New reservation date</param>
    /// <param name="reservationTime">New reservation time</param>
    void ChangeReservationDate(Reservation reservation, ReservationDate reservationDate,ReservationTime reservationTime);
    
    /// <summary>
    /// Change customer count
    /// </summary>
    /// <param name="reservation">Instance of <see cref="Reservation"/></param>
    /// <param name="customerCount">New customer count</param>
    void ChangeCustomerCount(Reservation reservation, CustomerCount customerCount);
}