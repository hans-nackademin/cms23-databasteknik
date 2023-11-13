using _03_Database_with_EntityFrameworkCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _03_Database_with_EntityFrameworkCore.Contexts;

internal class DataContext : DbContext
{
	public DataContext()
	{
	}

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-3\03_Database_with_EntityFrameworkCore\Data\local_db_entityframeworkcore.mdf;Integrated Security=True;Connect Timeout=30");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
