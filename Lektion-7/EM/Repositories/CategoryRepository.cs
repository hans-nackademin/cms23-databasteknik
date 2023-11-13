using EM.Entities;

namespace EM.Repositories;

public class CategoryRepository : Repository<CategoryEntity>
{
    public CategoryRepository(string databasePath) : base(databasePath)
    {
    }
}
