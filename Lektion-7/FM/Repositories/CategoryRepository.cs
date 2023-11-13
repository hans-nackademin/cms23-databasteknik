using FM.Contexts;
using FM.Models;

namespace FM.Repositories;

internal class CategoryRepository : Repository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
