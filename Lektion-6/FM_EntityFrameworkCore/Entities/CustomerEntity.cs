using Microsoft.EntityFrameworkCore;

namespace FM_EntityFrameworkCore.Entities;

[Index(nameof(Email), IsUnique = true)]
internal class CustomerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set; } = null!;

    public int CustomerTypeId { get; set; }
    public CustomerTypeEntity CustomerType { get; set; } = null!;
}
