using Core.ValueObject.Address;

namespace Core.Model.AddressModel;

/// <summary>
/// Represents Address.
/// </summary>
public class Address
{
    public City City { get; private set; }
    public Street Street { get; private set; }
    public HouseNumber HouseNumber { get; private set; }
    
    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Address()
    {
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="city">City</param>
    /// <param name="street">Street</param>
    /// <param name="houseNumber"></param>
    public Address(City city, Street street,HouseNumber houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }
}