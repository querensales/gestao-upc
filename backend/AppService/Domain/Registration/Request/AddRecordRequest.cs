namespace AppService.Domain.Registration.Request;

public record AddRecordRequest
{
    public string Name { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
} 