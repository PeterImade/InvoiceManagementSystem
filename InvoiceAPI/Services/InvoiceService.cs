using InvoiceAPI.Contracts.Repositories;
using InvoiceAPI.Contracts.Services;
using InvoiceAPI.DTOs.Invoice;
using InvoiceAPI.Exceptions;
using InvoiceAPI.Mappers;
using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public class InvoiceService(IInvoiceRepository _invoiceRepository) : IInvoiceService
    {
        public async Task<InvoiceResponse> AddInvoiceAsync(InvoiceCreateRequest request)
        {
            var invoice = request.ToEntity();
            invoice.TotalAmount = invoice.Items.Sum(x => x.TotalPrice);
            var createdInvoice = await _invoiceRepository.CreateAsync(invoice);
            return createdInvoice.ToDto();
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _invoiceRepository.GetAsync(id) ?? throw new InvoiceNotFoundException(id);
            await _invoiceRepository.DeleteAsync(invoice);
            return;
        }

        public async Task<List<InvoiceResponse>> GetAllInvoicesAsync()
        {
            var invoices = await _invoiceRepository.GetAllAsync();
            List<InvoiceResponse> responses = invoices.Select(x => x.ToDto()).ToList();
            return responses;
        }

        public async Task<InvoiceResponse?> GetInvoiceAsync(int id)
        {
            var invoice = await _invoiceRepository.GetAsync(id) ?? throw new InvoiceNotFoundException(id);
            return invoice.ToDto();
        }

        public async Task<InvoiceResponse?> GetInvoiceWithItemsAsync(int id)
        {
            var invoice = await _invoiceRepository.GetInvoiceWithItems(id) ?? throw new InvoiceNotFoundException(id);
            return invoice.ToDetailedDto();
        }

        public async Task UpdateInvoiceAsync(InvoiceUpdateRequest request)
        {
            var invoice = await _invoiceRepository.GetAsync(request.Id) ?? throw new InvoiceNotFoundException(request.Id);
            var invoiceToUpdate = request.ToUpdatedEntity(invoice);
            await _invoiceRepository.UpdateAsync(invoiceToUpdate);
            return;
        }
    }
}
