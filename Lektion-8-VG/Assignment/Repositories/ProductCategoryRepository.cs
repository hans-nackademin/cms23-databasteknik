using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

public interface IProductCategoryRepository : IRepo<ProductCategoryEntity>
{
}

public class ProductCategoryRepository : Repo<ProductCategoryEntity>, IProductCategoryRepository
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
