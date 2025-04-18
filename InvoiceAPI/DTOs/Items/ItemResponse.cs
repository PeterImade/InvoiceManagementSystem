namespace InvoiceAPI.DTOs.Item
{
    public record ItemResponse(int id, string Name, int Quantity, decimal UnitPrice, decimal TotalPrice, int InvoiceId, string createdAt);
}
