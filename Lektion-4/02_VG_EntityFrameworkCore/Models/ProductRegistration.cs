namespace _02_VG_EntityFrameworkCore.Models;

internal class ProductRegistration
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = null!;
}
