using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

public interface ICustomerTypeRepository : IRepo<CustomerTypeEntity>
{
}

public class CustomerTypeRepository : Repo<CustomerTypeEntity>, ICustomerTypeRepository
{
    public CustomerTypeRepository(DataContext context) : base(context)
    {
    }
}
