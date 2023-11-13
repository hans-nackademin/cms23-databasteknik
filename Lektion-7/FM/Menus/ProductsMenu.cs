using FM.Models;
using FM.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FM.Menus;

internal class ProductsMenu
{
    private readonly ProductService _productService;

    public ProductsMenu(ProductService productService)
    {
        _productService = productService;
    }

    public async Task ShowAsync()
    {
        var exit = false;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Show all Products");
            Console.WriteLine("2. Add new Product");
            Console.WriteLine("3. Show all Categories");
            Console.WriteLine("4. Add new Category");
            Console.WriteLine("0. Go Back");

            Console.Write("Choose one option: ");
            var goToOption = Console.ReadLine();

            switch (goToOption)
            {
                case "1":
                    await ShowAllProducts();
                    break;

                case "2":
                    await ShowCreateProduct();
                    break;

                case "3":

                    break;

                case "4":

                    break;

                case "0":
                    exit = true;
                    break;
            }
        }
        while (!exit);
    }

    public async Task ShowAllProducts()
    {

        Console.Clear();
        foreach (var product in await _productService.GetAllAsync())
            Console.WriteLine($"{product.ArticleNumber} - {product.Title}");

        Console.ReadKey();
    }

    public async Task ShowCreateProduct()
    {
        var productRegistration = new ProductRegistration();

        Console.Clear();
        Console.Write("Enter Article Number: ");
        productRegistration.ArticleNumber = Console.ReadLine()!;
        
        Console.Write("Enter Product Title: ");
        productRegistration.Title = Console.ReadLine()!;

        Console.Write("Enter Product Category: ");
        productRegistration.CategoryName = Console.ReadLine()!;

        await _productService.CreateAsync(productRegistration);
    }
}
