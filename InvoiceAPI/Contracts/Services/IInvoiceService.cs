using InvoiceAPI.DTOs.Invoice;
using InvoiceAPI.Models;

namespace InvoiceAPI.Contracts.Services
{
    public interface IInvoiceService
    {
        Task<InvoiceResponse> AddInvoiceAsync(InvoiceCreateRequest invoice);
        Task<InvoiceResponse?> GetInvoiceAsync(int id);
        Task<InvoiceResponse?> GetInvoiceWithItemsAsync(int id);
        Task<List<InvoiceResponse>> GetAllInvoicesAsync();
        Task UpdateInvoiceAsync(InvoiceUpdateRequest invoice);
        Task DeleteInvoiceAsync(int id);
    }
}
