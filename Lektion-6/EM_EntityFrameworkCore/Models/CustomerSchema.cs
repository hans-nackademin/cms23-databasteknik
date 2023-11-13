using System.ComponentModel.DataAnnotations;

namespace EM_EntityFrameworkCore.Models
{
    public class CustomerSchema
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required] public string Password { get; set; } = null!;
        [Required] public string StreetName { get; set; } = null!;
        [Required] public string PostalCode { get; set; } = null!;
        [Required] public string City { get; set; } = null!;
    }
}
