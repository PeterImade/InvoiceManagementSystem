using InvoiceAPI.DTOs.Invoice;
using InvoiceAPI.Models;
using InvoiceAPI.Helpers;

namespace InvoiceAPI.Mappers
{
    public static class InvoiceMapper
    {
        public static Invoice ToEntity(this InvoiceCreateRequest request)
        {
            return new Invoice
            {
                CustomerName = request.CustomerName,
                Status = request.Status,
                Items = request.Items.Select(x => new Item
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                }).ToList(),
                TotalAmount = request.Items.Sum(x => x.Quantity * x.UnitPrice)
            };
        }
        
        public static Invoice ToUpdatedEntity(this InvoiceUpdateRequest request, Invoice invoice)
        {
            invoice.CustomerName = UpdateHelpers.UpdateIfNotNullorEmpty(request.CustomerName, invoice.CustomerName);

            invoice.Status = (InvoiceStatus)UpdateHelpers.UpdateIfNotNull(request.Status, invoice.Status);

            return invoice;
        }

        public static InvoiceResponse ToDto(this Invoice request) => new InvoiceResponse(
            request.Id,
            request.CustomerName,
            request.InvoiceNumber,
            request.TotalAmount,
            request.Status,
            null
        );
        
        public static InvoiceResponse ToDetailedDto(this Invoice request) => new InvoiceResponse(
            request.Id,
            request.CustomerName,
            request.InvoiceNumber,
            request.TotalAmount,
            request.Status,
            request.Items
        );
    }
}
