using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EM_EntityFrameworkCore.Entities;

[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;
}
