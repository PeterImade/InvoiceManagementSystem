using InvoiceAPI.Contracts.Repositories;
using InvoiceAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
           var model = await _dbSet.AddAsync(entity);
           await SaveChanges();
            return model.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
