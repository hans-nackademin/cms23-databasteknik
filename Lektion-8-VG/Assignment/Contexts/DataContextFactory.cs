using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Assignment.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-8\Assignment\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30");
        return new DataContext(optionsBuilder.Options);
    }
}
