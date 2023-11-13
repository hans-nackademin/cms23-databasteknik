using System.ComponentModel.DataAnnotations;

namespace EM_EntityFrameworkCore.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public ICollection<CustomerEntity> Customers { get; set; } = new List<CustomerEntity>();
}
