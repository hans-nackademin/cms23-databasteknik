using FM.Models;
using FM.Repositories;

namespace FM.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;

    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(ProductRegistration productRegistration)
    {
        ProductEntity productEntity = productRegistration;

        CategoryEntity categoryEntity = await _categoryRepository.GetAsync(x => x.Name == productEntity.Category.Name);
        if (categoryEntity != null)
            productEntity.CategoryId = categoryEntity.Id;

        await _productRepository.CreateAsync(productEntity);
    }

    // DETTA ÄR FÖRMIDDAGEN




    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(x => new Product()).ToList();
    }
}
