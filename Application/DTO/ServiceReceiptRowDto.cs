namespace Application.DTO;

public class ServiceReceiptRowDto : ReceiptRowDto
{
    public Guid ServiceId { get; set; }
    public required string ServiceName { get; set; }
}