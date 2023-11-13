using EM_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EM_EntityFrameworkCore.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<InvoiceEntity> Invoices { get; set; }
        public DbSet<InvoiceLineEntity> InvoiceLines { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<QuantityUnitEntity> QuantityUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceLineEntity>().HasKey(x => new { x.InvoiceId, x.ProductId });
        }
    }
}
