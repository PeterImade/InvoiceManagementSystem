using InvoiceAPI.DTOs.Item;
using InvoiceAPI.Models;

namespace InvoiceAPI.Contracts.Services
{
    public interface IItemService
    {
        Task<ItemResponse> AddItemAsync(ItemCreateRequest request);
        Task<ItemResponse?> GetItemAsync(int id);
        Task<List<ItemResponse>> GetAllItemsAsync();
        Task DeleteItemAsync(int id);
        Task UpdateItemAsync(ItemUpdateRequest request );
    }
}
