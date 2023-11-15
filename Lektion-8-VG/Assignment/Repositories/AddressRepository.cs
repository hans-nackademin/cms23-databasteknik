using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

public interface IAddressRepository : IRepo<AddressEntity>
{
}

public class AddressRepository : Repo<AddressEntity>, IAddressRepository
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
