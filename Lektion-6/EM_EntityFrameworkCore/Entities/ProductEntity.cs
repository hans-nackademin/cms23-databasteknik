using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM_EntityFrameworkCore.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal StockPrice { get; set; }
}
