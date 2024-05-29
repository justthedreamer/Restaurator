using Core.Model.RestaurantModel;
using Core.ValueObject.Reservation;
using Core.ValueObject.Staff.Employee;

namespace Core.Model.ReservationModel;

/// <summary>
/// Represents customer reservation.
/// </summary>
public class Reservation
{
    public ReservationId ReservationId { get; private set; }
    public Table Table { get; private set; }
    public FirstName CustomerFirstName { get; private set; }
    public LastName CustomerLastName { get; private set; }
    public ReservationDate ReservationDate { get; private set; }
    public ReservationTime ReservationTime { get; private set; }
    public CustomerCount CustomerCount { get; private set; }

    /// <summary>
    /// Change table
    /// </summary>
    /// <param name="table">New table</param>
    internal void ChangeTable(Table table) => Table = table;

    /// <summary>
    /// Change customer name
    /// </summary>
    /// <param name="firstName">Customer first name</param>
    /// <param name="lastName">Customer last name</param>
    internal void ChangeCustomerName(FirstName firstName, LastName lastName)
    {
        CustomerFirstName = firstName;
        CustomerLastName = lastName;
    }

    /// <summary>
    /// Change reservation date
    /// </summary>
    /// <param name="reservationDate">Reservation date</param>
    /// <param name="reservationTime">Reservation time in hours</param>
    internal void ChangeReservationDate(ReservationDate reservationDate, ReservationTime reservationTime)
    {
        ReservationDate = reservationDate;
        ReservationTime = reservationTime;
    }

    /// <summary>
    /// Change customer count
    /// </summary>
    /// <param name="customerCount"></param>
    internal void ChangeCustomerCount(CustomerCount customerCount) => CustomerCount = customerCount;
    
    /// <summary>
    /// Empty constructor for entity framework.
    /// </summary>
    private Reservation()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="reservationId">Reservation ID</param>
    /// <param name="table">Table</param>
    /// <param name="customerFirstName">Customer First name</param>
    /// <param name="customerLastName">Customer Last name</param>
    /// <param name="reservationDate">Reservation Date</param>
    /// <param name="reservationTime">Reservation time</param>
    /// <param name="customerCount">Customer count</param>
    public Reservation(ReservationId reservationId, Table table, FirstName customerFirstName, LastName customerLastName, ReservationDate reservationDate, ReservationTime reservationTime, CustomerCount customerCount)
    {
        ReservationId = reservationId;
        Table = table;
        CustomerFirstName = customerFirstName;
        CustomerLastName = customerLastName;
        ReservationDate = reservationDate;
        ReservationTime = reservationTime;
        CustomerCount = customerCount;
    }
}