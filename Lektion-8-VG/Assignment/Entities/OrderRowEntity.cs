using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Entities;

public class OrderRowEntity 
{ 
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; } = null!;
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int Quantity { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

}
