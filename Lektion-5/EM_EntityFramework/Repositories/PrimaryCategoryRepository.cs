using EM_EntityFramework.Contexts;
using EM_EntityFramework.Entities;

namespace EM_EntityFramework.Repositories;

internal class PrimaryCategoryRepository : Repo<PrimaryCategoryEntity>
{
    private readonly DataContext _context;
    public PrimaryCategoryRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override Task<IEnumerable<PrimaryCategoryEntity>> ReadAsync()
    {
        return base.ReadAsync();
    }
}
