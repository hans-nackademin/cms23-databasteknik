using EM.Models;

namespace EM.Entities;

public class ProductEntity
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public int CategoryId { get; set; }

    public static implicit operator ProductEntity(ProductRegistration form)
    {
        return new ProductEntity
        {
            ArticleNumber = form.ArticleNumber,
            Title = form.Title
        };
    }
}
