using InvoiceAPI.DTOs.Item;
using InvoiceAPI.Helpers;
using InvoiceAPI.Models;

namespace InvoiceAPI.Mappers
{
    public static class ItemMapper
    {
        public static Item ToEntity(this ItemCreateRequest request)
        {
            return new Item
            {
                Name = request.Name,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
            };
        }

        public static Item ToUpdatedEntity(this ItemUpdateRequest request, Item item)
        {
             item.Name = UpdateHelpers.UpdateIfNotNullorEmpty(request.Name, item.Name);
            item.Quantity = (int)UpdateHelpers.UpdateIfNotNull(request.Quantity, request.Quantity);
            item.UnitPrice = (decimal)UpdateHelpers.UpdateIfNotNull(request.UnitPrice, request.UnitPrice);
            return item;
        }

        public static ItemResponse ToDto(this Item item)
        {
            return new ItemResponse
                (
                    item.Id,
                    item.Name,
                    item.Quantity,
                    item.UnitPrice,
                    item.TotalPrice,
                    item.InvoiceId,
                    item.CreatedAt
                );
        }
    }
}
