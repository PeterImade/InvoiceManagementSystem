using InvoiceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceAPI.DTOs.Invoice
{
    public record InvoiceUpdateRequest 
        (
        [property: JsonPropertyName("id")]
        int Id,
        [property: JsonPropertyName("customerName")]
        string? CustomerName,
        [property: JsonPropertyName("status")]
        InvoiceStatus? Status
        );
}
