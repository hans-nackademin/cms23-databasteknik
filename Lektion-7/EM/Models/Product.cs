using EM.Entities;

namespace EM.Models;

public class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string CategoryName { get; set; } = null!;

    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            ArticleNumber = entity.ArticleNumber,
            Title = entity.Title
        };
    }
}
