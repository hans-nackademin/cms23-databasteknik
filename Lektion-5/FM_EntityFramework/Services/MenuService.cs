using FM_EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_EntityFramework.Services
{
    internal class MenuService
    {
        private readonly ProductService _productService;

        public MenuService(ProductService productService)
        {
            _productService = productService;
        }

        public async Task AddProduct()
        {
            var product = new ProductRegistration();

            Console.Write("Produktens namn: ");
            product.Name = Console.ReadLine()!;

            Console.Write("Beskrivning: ");
            product.Description = Console.ReadLine()!;

            Console.Write("Pris: ");
            product.Price = decimal.Parse(Console.ReadLine()!);

            Console.Write("kategorinamn: ");
            product.CategoryName = Console.ReadLine()!;
        
            await _productService.CreateProductAsync(product);
        }

        public async Task ListAllProducts()
        {
            Console.WriteLine("Alla produkter");
            foreach (var product in await _productService.GetAllProductsAsync())
            {
                Console.WriteLine($"{product.Name} - {product.Category.CategoryName}");
                Console.WriteLine($"{product.Description}");
                Console.WriteLine($"{product.Price}");
                Console.WriteLine($"");
            }

            Console.ReadKey();
        }
    }
}
