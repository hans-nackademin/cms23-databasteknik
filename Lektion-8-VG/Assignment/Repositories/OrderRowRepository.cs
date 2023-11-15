using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

public class OrderRowRepository : Repo<OrderRowEntity>
{
    public OrderRowRepository(DataContext context) : base(context)
    {
    }
}
