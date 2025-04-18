using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.DTOs.Item
{
    public record ItemUpdateRequest
    ( 
        int Id,
        string? Name,
        int? Quantity,
        decimal? UnitPrice
    );
}
