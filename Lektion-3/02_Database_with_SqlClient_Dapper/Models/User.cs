namespace _02_Database_with_SqlClient_Dapper.Models;

internal class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set;} = null!;
    public string Email { get; set; } = null!;
    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;
}
