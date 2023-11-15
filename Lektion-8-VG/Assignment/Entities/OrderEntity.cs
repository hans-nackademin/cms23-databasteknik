using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal TotalPrice { get; set; }

    public ICollection<OrderRowEntity> OrderRows { get; set; } = new List<OrderRowEntity>();
}
