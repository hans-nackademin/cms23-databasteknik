using System.ComponentModel.DataAnnotations;

namespace _01_G_EntityFrameworkCore.Entities;

internal class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int RoleId { get; set; }
    public RoleEntity Role { get; set; } = null!;

    [Required]
    public int AddressId { get; set; }
    public AddressEntity Address { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public bool IsEnabled { get; set; }
}
