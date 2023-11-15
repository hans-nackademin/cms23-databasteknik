using System.ComponentModel.DataAnnotations;

namespace Assignment.Entities;

public class ProductCategoryEntity
{
    [Key]
    public int Id { get; set; } 
    public string CategoryName { get; set; } = null!;
}