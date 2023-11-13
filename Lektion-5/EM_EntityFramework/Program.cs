using EM_EntityFramework.Contexts;
using EM_EntityFramework.Models;
using EM_EntityFramework.Repositories;
using EM_EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EM_EntityFramework;

internal class Program
{
    private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-5\EM_EntityFramework\Contexts\em_database.mdf;Integrated Security=True;Connect Timeout=30";

    static async Task Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder()
            .ConfigureServices(services => {
                
                services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));
                services.AddScoped<SubCategoryRepository>();
                services.AddScoped<PrimaryCategoryRepository>();
                services.AddScoped<ProductRepository>();
                services.AddScoped<ProductService>();
            }).Build();

        using (var scope = builder.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var productService = services.GetRequiredService<ProductService>();

            var productRegistration = new ProductRegistration
            {
                ArticleNumber = Guid.NewGuid().ToString(),
                Name = "Product 1",
                Description = "Description for product 1",
                Price = 100,
                SubCategory = "Stationär",
                PrimaryCategory = "Datorer"
            };
            
            var result = await productService.CreateProductAsync(productRegistration);
            var json = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            Console.WriteLine(json);
            Console.ReadKey();
        }

        await builder.RunAsync();


    }
}