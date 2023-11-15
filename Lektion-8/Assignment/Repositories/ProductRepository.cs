using Assignment.Contexts;
using Assignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repositories;

internal class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.PricingUnit)
            .Include(x => x.ProductCategory)
            .ToListAsync();
    }
}
