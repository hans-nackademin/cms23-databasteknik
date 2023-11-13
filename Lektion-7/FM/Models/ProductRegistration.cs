using System.ComponentModel.DataAnnotations;

namespace FM.Models;

internal class ProductRegistration
{
    public string ArticleNumber { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string CategoryName { get; set; } = null!;

}
