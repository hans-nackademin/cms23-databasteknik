using FM_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace FM_EntityFrameworkCore.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<CustomerTypeEntity> CustomerTypes { get; set; }
}
