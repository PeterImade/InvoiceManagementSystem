using InvoiceAPI.Models;

namespace InvoiceAPI.Contracts.Repositories
{
    public interface IInvoiceRepository: IGenericRepository<Invoice>
    {
        Task<Invoice?> GetInvoiceWithItems(int id);
    }
}
