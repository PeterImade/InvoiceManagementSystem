using InvoiceAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InvoiceAPI.DTOs.Invoice
{
    public record InvoiceResponse
        (
            int Id,

            string CustomerName,
            string InvoiceNumber,

            [property: DisplayFormat(DataFormatString = "{0:C}")]
            [property: JsonPropertyName("total")]
            decimal TotalAmount,
            [property: JsonConverter(typeof(JsonStringEnumConverter))]
            InvoiceStatus Status,
            List<InvoiceAPI.Models.Item>? Items
        );
}
