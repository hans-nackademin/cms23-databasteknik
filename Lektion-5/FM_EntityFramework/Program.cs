using FM_EntityFramework.Contexts;
using FM_EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FM_EntityFramework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\education\\cms23\\databasteknik\\Lektion-5\\FM_EntityFramework\\Contexts\\database.mdf;Integrated Security=True;Connect Timeout=30"));

                    services.AddScoped<CategoryService>();
                    services.AddScoped<ProductService>();
                    services.AddScoped<MenuService>();

                })
                .Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var menuService = services.GetRequiredService<MenuService>();
                
                await menuService.AddProduct();
                await menuService.ListAllProducts();
            }

            await host.RunAsync();

        }
    }
}
