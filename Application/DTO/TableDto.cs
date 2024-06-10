namespace Application.DTO;

public sealed record TableDto
{
    public Guid TableId { get; set; }
    public string TableSign { get; set; }
    public int SeatsCount { get; set; }
}