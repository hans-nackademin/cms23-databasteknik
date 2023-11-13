using FM.Contexts;
using FM.Models;
using Microsoft.EntityFrameworkCore;

namespace FM.Repositories;

internal class ProductRepository : Repository<ProductEntity>
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = await _context.Products.Include(x => x.Category).ToListAsync();
        return products;
    }
}
