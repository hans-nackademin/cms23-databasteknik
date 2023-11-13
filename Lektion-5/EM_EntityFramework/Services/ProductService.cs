using EM_EntityFramework.Entities;
using EM_EntityFramework.Models;
using EM_EntityFramework.Repositories;

namespace EM_EntityFramework.Services;

internal class ProductService
{
    private readonly ProductRepository _productRepo;
    private readonly SubCategoryRepository _subCategoryRepo;

    public ProductService(ProductRepository productRepo, SubCategoryRepository subCategoryRepo)
    {
        _productRepo = productRepo;
        _subCategoryRepo = subCategoryRepo;
    }


    public async Task<Product> CreateProductAsync(ProductRegistration registration)
    {
        var item = await _productRepo.ReadAsync(x => x.ArticleNumber == registration.ArticleNumber);
        if (item == null) 
        {
            var entity = new ProductEntity { 
                ArticleNumber = registration.ArticleNumber,
                Name = registration.Name,
                Description = registration.Description,
                Price = registration.Price,
                SubCategoryId = (await _subCategoryRepo.ReadAsync(x => x.SubCategoryName == registration.SubCategory)).Id
            };

            entity = await _productRepo.CreateAsync(entity);

            var product = new Product
            {
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                SubCategory = entity.SubCategory.SubCategoryName,
                PrimaryCategory = entity.SubCategory.PrimaryCategory.CategoryName
            };
            
            return product;


        }

        return null!;
    }
}
