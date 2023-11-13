namespace FM.Models;

internal class Product
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;

    public static implicit operator Product(ProductEntity product)
    {
        return new Product
        {
            ArticleNumber = product.ArticleNumber,
            Title = product.Title,
        };
    }
}
