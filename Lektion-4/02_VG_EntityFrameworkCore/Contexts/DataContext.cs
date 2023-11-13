using _02_VG_EntityFrameworkCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_VG_EntityFrameworkCore.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
}
