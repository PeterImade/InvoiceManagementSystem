using InvoiceAPI.Contracts.Services;
using InvoiceAPI.DTOs.Item;
using InvoiceAPI.Models;
using InvoiceAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceAPI.Controllers
{
    [Route("api/v1/items")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            this._itemService = itemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var item = await _itemService.GetItemAsync(id);
            return item is null
                ? NotFound(new { Message = $"Item with ID {id} not found." })
                : Ok(item);
        }
         
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] ItemCreateRequest item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid item data.", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            var createdItem = await _itemService.AddItemAsync(item);

            return CreatedAtAction(nameof(GetItem), new { id = createdItem.id }, createdItem);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] ItemUpdateRequest item)
        {
            if (id != item.Id)
            {
                return BadRequest(new { Message = "Item ID mismatch between URL and body." });
            }

            await _itemService.UpdateItemAsync(item);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var item = await _itemService.GetItemAsync(id);

            if (item is null)
            {
                return NotFound(new { Message = $"Item with ID {id} not found." });
            }

            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
