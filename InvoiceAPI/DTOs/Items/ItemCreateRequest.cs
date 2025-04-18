using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.DTOs.Item
{
    public record ItemCreateRequest
    {
        [StringLength(20, ErrorMessage = "Name must not be above 20 characters")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }


        [Required(ErrorMessage = "Unit Price is Required")]
        public decimal UnitPrice { get; set; }
    };
}