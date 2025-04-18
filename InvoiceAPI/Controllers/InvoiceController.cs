using InvoiceAPI.Contracts.Services;
using InvoiceAPI.DTOs.Invoice;
using InvoiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceAPI.Controllers
{
    [Route("api/v1/invoices")]
    [ApiController]
    public class InvoiceController(IInvoiceService _invoiceService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(new ApiResponse(invoices, "Invoices fetched successfully"));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int id)
        {  
            var invoice = await _invoiceService.GetInvoiceWithItemsAsync(id);
            return Ok(new ApiResponse(invoice, "Invoice fetched successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceCreateRequest invoiceRequest)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(new { Message = "Invalid invoice data.", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            var createdInvoice = await _invoiceService.AddInvoiceAsync(invoiceRequest);

            return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.Id }, createdInvoice);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] int id, [FromBody] InvoiceUpdateRequest invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest(new { Message = "Invoice ID mismatch between URL and body." });
            }

            await _invoiceService.UpdateInvoiceAsync(invoice);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        { 
            await _invoiceService.DeleteInvoiceAsync(id);
            return NoContent();
        }
    }
}