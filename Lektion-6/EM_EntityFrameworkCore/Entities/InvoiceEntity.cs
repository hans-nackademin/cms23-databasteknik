using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EM_EntityFrameworkCore.Entities;

public class InvoiceEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);

    public string CustomerNumber { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string? AddressLine_1 { get; set; }
    public string? AddressLine_2 { get; set;}
    public string? PostalCode { get; set; }
    public string? City { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }
    [Column(TypeName = "money")]
    public decimal Vat {  get; set; }
}
