using System.ComponentModel.DataAnnotations.Schema;

namespace EM_EntityFrameworkCore.Entities;

public class InvoiceLineEntity
{
    public int InvoiceId { get; set; }
    public InvoiceEntity Invoice { get; set; } = null!;

    public int ProductId { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
    public int QuantityUnitId { get; set; }
    public QuantityUnitEntity QuantityUnit { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
}
