using System.ComponentModel.DataAnnotations;

namespace FM.Models;

internal class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;

    public static implicit operator ProductEntity(ProductRegistration product)
    {
        return new ProductEntity
        {
            ArticleNumber = product.ArticleNumber,
            Title = product.Title,
            Category = new CategoryEntity
            {
                Name = product.CategoryName
            }
        };
    }
}
