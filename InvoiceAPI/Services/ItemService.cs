using InvoiceAPI.Contracts.Repositories;
using InvoiceAPI.Contracts.Services;
using InvoiceAPI.DTOs.Item;
using InvoiceAPI.Mappers;
using InvoiceAPI.Models;

namespace InvoiceAPI.Services
{
    public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            this._itemRepository = itemRepository;
        }

        public async Task<ItemResponse> AddItemAsync(ItemCreateRequest request)
        {
            var item = request.ToEntity();
            var createdItem  = await _itemRepository.CreateAsync(item);
            var response = createdItem.ToDto();
            return response;
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetAsync(id);
            await _itemRepository.DeleteAsync(item);
            return;
        }

        public async Task<List<ItemResponse>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllAsync();
            var response = items.Select(x => x.ToDto()).ToList();
            return response;
        }

        public async Task<ItemResponse?> GetItemAsync(int id)
        {
            var item = await _itemRepository.GetAsync(id);
            var response = item.ToDto();
            return response;
        }

        public async Task UpdateItemAsync(ItemUpdateRequest request)
        {
            var item = await _itemRepository.GetAsync(request.Id);
            var itemToUpdate = request.ToUpdatedEntity(item);
            await _itemRepository.UpdateAsync(itemToUpdate);
            return;
        }
    }
}
