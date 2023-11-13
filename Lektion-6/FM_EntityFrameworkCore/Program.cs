using FM_EntityFrameworkCore.Contexts;
using FM_EntityFrameworkCore.Repositories;
using FM_EntityFrameworkCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace FM_EntityFrameworkCore;

internal class Program
{
    static async Task Main(string[] args)
    {

        var services = new ServiceCollection();
        
        services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-6\FM_EntityFrameworkCore\Contexts\fm_database.mdf;Integrated Security=True;Connect Timeout=30"));
        services.AddScoped<CustomerRepository>();
        services.AddScoped<CustomerTypeRepository>();
        services.AddScoped<CustomerTypeService>();
        services.AddScoped<MenuService>();

        using var sp = services.BuildServiceProvider();

        var menuService = sp.GetRequiredService<MenuService>();
        await menuService.CreateCustomerTypeMenuAsync();
    }
}

