using Microsoft.EntityFrameworkCore;

namespace EM_EntityFrameworkCore.Entities;

[Index(nameof(UnitName), IsUnique = true)]
public class QuantityUnitEntity
{
    public int Id { get; set; }
    public string UnitName { get; set; } = null!;

    public ICollection<InvoiceLineEntity> InvoiceLines { get; set; } = new HashSet<InvoiceLineEntity>();
}