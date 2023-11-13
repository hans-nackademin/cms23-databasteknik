using System.ComponentModel.DataAnnotations;

namespace _01_G_EntityFrameworkCore.Entities;

internal class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Category { get; set; }
}
