using _02_VG_EntityFrameworkCore.Contexts;
using _02_VG_EntityFrameworkCore.Repositories;
using _02_VG_EntityFrameworkCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _02_VG_EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-4\02_VG_EntityFrameworkCore\Contexts\vg_database.mdf;Integrated Security=True;Connect Timeout=30"));
                services.AddScoped<ProductRepository>();
                services.AddScoped<ProductService>();
            })
            .Build();

        await host.RunAsync();
    }
}