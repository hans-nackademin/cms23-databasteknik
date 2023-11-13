namespace EM_EntityFramework.Models;

internal class ProductRegistration
{
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string PrimaryCategory { get; set; } = null!;
    public string SubCategory { get; set; } = null!;
}
