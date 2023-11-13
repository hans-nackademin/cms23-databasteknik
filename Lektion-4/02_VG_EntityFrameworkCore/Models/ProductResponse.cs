using _02_VG_EntityFrameworkCore.Enums;

namespace _02_VG_EntityFrameworkCore.Models;

internal class ProductResponse
{
    public StatusCodes Status { get; set; }
    public Product? Product { get; set; }
}
