namespace Application.DTO;

public class ServiceReceiptRowDto : ReceiptRowDto
{
    public required ServiceDto ServiceDto { get; init; }
}