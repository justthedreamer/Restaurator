using Core.ValueObject.Restaurant;

namespace Core.Model.RestaurantModel;

/// <summary>
/// Represent restaurant table
/// </summary>
public class Table
{
    public TableId TableId { get; private set; }
    public TableSign TableSign { get; private set; }
    public SeatsCount SeatsCount { get; private set; }

    /// <summary>
    /// Change seats count
    /// </summary>
    /// <param name="seatsCount">Seats count</param>
    internal void ChangeSeatsCount(ushort seatsCount) => SeatsCount = seatsCount;

    internal void ChangeTableSign(TableSign tableSign) => TableSign = tableSign; 
    
    /// <summary>
    /// Empty constructor for Entity Framework
    /// </summary>
    private Table()
    {
        
    }

    /// <summary>
    /// General constructor
    /// </summary>
    /// <param name="tableId">Table ID</param>
    /// <param name="tableSign">Table sign</param>
    /// <param name="seatsCount">Seats count</param>
    public Table(TableId tableId,TableSign tableSign, SeatsCount seatsCount)
    {
        TableId = tableId;
        TableSign = tableSign;
        SeatsCount = seatsCount;
    }
}

