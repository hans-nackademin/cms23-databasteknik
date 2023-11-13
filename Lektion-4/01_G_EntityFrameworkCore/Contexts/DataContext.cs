using _01_G_EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_G_EntityFrameworkCore.Contexts;

internal class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-4\01_G_EntityFrameworkCore\Contexts\g_database.mdf;Integrated Security=True;Connect Timeout=30");
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}
