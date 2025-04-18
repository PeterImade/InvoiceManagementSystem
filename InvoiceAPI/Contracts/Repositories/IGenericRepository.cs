namespace InvoiceAPI.Contracts.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetAsync(int id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
