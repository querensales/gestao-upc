namespace AppService.Domain.Registration.Response;

public record BalanceSummaryResponse
{
    public decimal TotalBalance { get; set; }
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
} 