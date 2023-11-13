using _02_VG_EntityFrameworkCore.Models.Entities;
using System.Diagnostics;

namespace _02_VG_EntityFrameworkCore.Models;

internal class Product
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? CategoryName { get; set; }

    public static implicit operator Product(ProductEntity entity)
    {
        try
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
