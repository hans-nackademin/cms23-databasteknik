using _02_VG_EntityFrameworkCore.Models;
using _02_VG_EntityFrameworkCore.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace _02_VG_EntityFrameworkCore.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductResponse> CreateProductAsync(ProductRegistration productRegistration)
    {
        // CHECK IF EXISTS
        if (!await _productRepository.ExistsAsync(x => x.Name == productRegistration.Name))
        {
            var product = await _productRepository.CreateAsync(productRegistration);
            if (product != null)
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.CREATED,
                    Product = product,
                };
            else 
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.ERROR,
                    Product = null
                };  
        }
        else

            return new ProductResponse
            {
                Status = Enums.StatusCodes.CONFLICT,
                Product = null
            };

    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        var products = new List<Product>();
        try
        {
            var items = await _productRepository.ReadAsync();
            foreach (var item in items)
                products.Add(item);

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return products;
    }
    public async Task<ProductResponse> GetProductByNameAsync(string productName)
    {
        try
        {
            var item = await _productRepository.ReadAsync(x => x.Name == productName);
            if (item != null)
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.OK,
                    Product = item
                };
            else
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.NOTFOUND,
                    Product = null
                };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return new ProductResponse
        {
            Status = Enums.StatusCodes.ERROR,
            Product = null
        };
    }
    public async Task<ProductResponse> GetProductByIdAsync(int productId)
    {
        try
        {
            var item = await _productRepository.ReadAsync(x => x.Id == productId);
            if (item != null)
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.OK,
                    Product = item
                };
            else
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.NOTFOUND,
                    Product = null
                };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return new ProductResponse
        {
            Status = Enums.StatusCodes.ERROR,
            Product = null
        };
    }
    public async Task<ProductResponse> UpdateProductAsync(int productId, ProductUpdate updatedProduct)
    {
        try
        {
            var product = await _productRepository.ReadAsync(x => x.Id == productId);
            if (product != null)
            {
                product.Name = updatedProduct.Name ?? product.Name;
                product.Description = updatedProduct.Description ?? product.Description;
                product.Price = updatedProduct.Price ?? product.Price;

                product = await _productRepository.UpdateAsync(product);
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.OK,
                    Product = product
                };
            }
            else
                return new ProductResponse
                {
                    Status = Enums.StatusCodes.NOTFOUND,
                    Product = null
                };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return new ProductResponse
        {
            Status = Enums.StatusCodes.ERROR,
            Product = null
        };
    }
    public async Task<bool> DeleteProductAsync(int productId)
    {
        try
        {
            var product = await _productRepository.ReadAsync(x => x.Id == productId);
            if (product != null)
                return await _productRepository.DeleteAsync(product);
            
            else
                return false;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
