using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceAPI.Models
{

    [Table("Invoices")]
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Name must not be above 20 characters")]
        public string CustomerName { get; set; }
        public string InvoiceNumber { get; set; } = Guid.NewGuid().ToString();
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }
        public InvoiceStatus Status { get; set; }
        // Relationships
        public List<Item> Items { get; set; } = new List<Item>();
        public string CreatedAt { get; set; } = DateTime.Now.ToShortDateString();
    }
}
