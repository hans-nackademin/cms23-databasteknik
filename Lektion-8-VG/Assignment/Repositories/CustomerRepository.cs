using Assignment.Contexts;
using Assignment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Repositories;


public interface ICustomerRepository : IRepo<CustomerEntity>
{
}

public class CustomerRepository : Repo<CustomerEntity>, ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers
            .Include(x => x.Address)
            .Include(x => x.CustomerType)
            .ToListAsync();
    }
}
