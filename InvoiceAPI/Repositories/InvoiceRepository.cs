using InvoiceAPI.Contracts.Repositories;
using InvoiceAPI.Data;
using InvoiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Repositories
{
    public class InvoiceRepository: GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context): base(context)
        {
            
        }

        public async Task<Invoice?> GetInvoiceWithItems(int id)
        {
            var invoice = await _dbSet.Include(x => x.Items).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return invoice;
        }
    }
}
