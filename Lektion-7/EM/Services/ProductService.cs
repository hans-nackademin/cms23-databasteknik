using EM.Entities;
using EM.Models;
using EM.Repositories;
using System.Diagnostics;

namespace EM.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;

    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateProductAsync(ProductRegistration productRegistration)
    {
        try
        {
            ProductEntity productEntity = productRegistration;

            CategoryEntity categoryEntity = await _categoryRepository.GetAsync("SELECT * FROM Categories WHERE CategoryName = @CategoryName", productRegistration);
            if (categoryEntity != null)
                productEntity.CategoryId = categoryEntity.Id;
            else
            {       
                await _categoryRepository.CreateAsync("INSERT INTO Categories VALUES (@CategoryName)", productRegistration);
                categoryEntity = await _categoryRepository.GetAsync("SELECT * FROM Categories WHERE CategoryName = @CategoryName", productRegistration);
                productEntity.CategoryId = categoryEntity.Id;
            }
                

            await _productRepository.CreateAsync("INSERT INTO Products VALUES (@ArticleNumber, @Title, @CategoryId)", productEntity);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        try
        {
            var products = await _productRepository.GetAllWithCategoryAsync("SELECT * FROM Products p JOIN Categories c ON c.Id = p.CategoryId");
            return products;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); return null; }
    }
}

// DETTA ÄR NU