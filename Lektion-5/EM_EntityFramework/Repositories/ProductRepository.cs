using EM_EntityFramework.Contexts;
using EM_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EM_EntityFramework.Repositories;

internal class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        var result = await base.CreateAsync(entity);
        var product = await _context.Products.Include(x => x.SubCategory).ThenInclude(x => x.PrimaryCategory).FirstOrDefaultAsync(x => x.ArticleNumber == result.ArticleNumber);
        return product!;
    }
}
