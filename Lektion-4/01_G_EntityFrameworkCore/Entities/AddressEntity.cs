using System.ComponentModel.DataAnnotations;

namespace _01_G_EntityFrameworkCore.Entities;

internal class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string StreetName { get; set; } = null!;

    [Required]
    [StringLength(10)]
    public string PostalCode { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;
}
