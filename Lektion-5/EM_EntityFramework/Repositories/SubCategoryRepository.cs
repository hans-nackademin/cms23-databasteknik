using EM_EntityFramework.Contexts;
using EM_EntityFramework.Entities;

namespace EM_EntityFramework.Repositories;

internal class SubCategoryRepository : Repo<SubCategoryEntity>
{
    private readonly DataContext _context;
    public SubCategoryRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
