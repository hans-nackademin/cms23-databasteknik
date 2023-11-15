using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

internal class ProductCategoryRepository : Repo<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
