using Assignment.Contexts;
using Assignment.Menus;
using Assignment.Repositories;
using Assignment.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-8\Assignment\Contexts\assignment_database.mdf;Integrated Security=True;Connect Timeout=30"));

            // Repositories
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<PricingUnitRepository>();
            services.AddScoped<ProductCategoryRepository>();
            services.AddScoped<ProductRepository>();
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();

            // Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ProductService>();

            // Menus
            services.AddScoped<CustomerMenu>();
            services.AddScoped<ProductMenu>();
            services.AddScoped<MainMenu>();


            var sp = services.BuildServiceProvider();
            var mainMenu = sp.GetRequiredService<MainMenu>();
            await mainMenu.StartAsync();
        }
    }
}
