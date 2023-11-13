using EM_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EM_EntityFramework.Contexts;

internal class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<SubCategoryEntity> SubCategories { get; set; }
    public DbSet<PrimaryCategoryEntity> PrimaryCategories { get; set; }

}
