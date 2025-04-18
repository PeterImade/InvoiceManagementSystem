using InvoiceAPI.DTOs.Item;
using InvoiceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceAPI.DTOs.Invoice
{
    public record InvoiceCreateRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name must not be above 20 characters")]
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public InvoiceStatus Status { get; set; }

        [JsonPropertyName("items")]
        public List<ItemCreateRequest>? Items { get; set; } = new();
    };

}
