using InvoiceAPI.Contracts.Repositories;
using InvoiceAPI.Data;
using InvoiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Repositories
{
    public class ItemRepository: GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
