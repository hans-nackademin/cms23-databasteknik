using FM.Contexts;
using FM.Menus;
using FM.Repositories;
using FM.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FM;

internal class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-7\FM\Contexts\fm_database.mdf;Integrated Security=True;Connect Timeout=30"));
        
        services.AddScoped<MainMenu>();
        services.AddScoped<ProductsMenu>();
        services.AddScoped<CustomersMenu>();
        services.AddScoped<OrdersMenu>();
        services.AddScoped<ProductService>();
        services.AddScoped<ProductRepository>();
        services.AddScoped<CategoryRepository>();

        using var sp = services.BuildServiceProvider();
        var mainMenu = sp.GetRequiredService<MainMenu>();
        await mainMenu.ShowAsync();
    }
}