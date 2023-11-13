using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace _02_VG_EntityFrameworkCore.Models.Entities;

internal class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }


    public static implicit operator ProductEntity(ProductRegistration reg)
    {
        try
        {
            return new ProductEntity
            {
                Name = reg.Name,
                Price = reg.Price,
                Description = reg.Description
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
