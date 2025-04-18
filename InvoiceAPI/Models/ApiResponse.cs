namespace InvoiceAPI.Models
{
    public record ApiResponse(object? Data, string? Message = null, bool Success = true);
}
