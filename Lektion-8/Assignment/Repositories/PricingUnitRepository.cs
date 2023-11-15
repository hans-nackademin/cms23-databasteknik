using Assignment.Contexts;
using Assignment.Entities;

namespace Assignment.Repositories;

internal class PricingUnitRepository : Repo<PricingUnitEntity>
{
    public PricingUnitRepository(DataContext context) : base(context)
    {
    }
}
