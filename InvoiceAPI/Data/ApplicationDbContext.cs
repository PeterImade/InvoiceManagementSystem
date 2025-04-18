using InvoiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasOne(i => i.Invoice).WithMany(inv => inv.Items).HasForeignKey(i => i.InvoiceId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Invoice>().HasData(
     new Invoice
     {
         Id = 1,
         CustomerName = "James Stuart",
         Status = InvoiceStatus.Paid,
         TotalAmount = 300m
     }
 );
        }
    }
}
