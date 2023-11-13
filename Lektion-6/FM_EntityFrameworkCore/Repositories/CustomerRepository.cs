using FM_EntityFrameworkCore.Contexts;
using FM_EntityFrameworkCore.Entities;

namespace FM_EntityFrameworkCore.Repositories;

internal class CustomerRepository : Repo<CustomerEntity>
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}
