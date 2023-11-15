using Assignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<PricingUnitEntity> PricingUnits { get; set; }
    public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }
    public DbSet<OrderRowEntity> OrderRows { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderRowEntity>().HasKey(x => new { x.OrderId, x.ProductId });
    }
}
