using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InvoiceAPI.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(20, ErrorMessage = "Name must not be above 20 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        [Precision(18, 2)]
        public decimal TotalPrice { get => Quantity * UnitPrice; }
        public int InvoiceId { get; set; }

        [JsonIgnore]
        public Invoice Invoice { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToShortDateString();
    }
}
