using FM_EntityFrameworkCore.Contexts;
using FM_EntityFrameworkCore.Entities;

namespace FM_EntityFrameworkCore.Repositories;

internal class CustomerTypeRepository : Repo<CustomerTypeEntity>
{
    private readonly DataContext _context;

    public CustomerTypeRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
