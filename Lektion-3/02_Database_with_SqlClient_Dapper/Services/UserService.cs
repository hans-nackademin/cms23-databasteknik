using _02_Database_with_SqlClient_Dapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _02_Database_with_SqlClient_Dapper.Services;

internal class UserService
{
    private readonly string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-3\02_Database_with_SqlClient_Dapper\Data\local_db_dapper.mdf;Integrated Security=True;Connect Timeout=30";

    public bool CreateUser(User user)
    {
        try
        {
            var addressService = new AddressService();

            var addressId = addressService.CreateAddress(user.Address);
            if (addressId > 0)
            {
                user.AddressId = addressId;

                using var conn = new SqlConnection(connectionstring);
                var result = conn.ExecuteScalar<int>("IF NOT EXISTS (SELECT Id FROM Users WHERE Email = @Email) INSERT INTO Users OUTPUT INSERTED.Id VALUES (@FirstName, @LastName, @Email, @AddressId)", user);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        
        return false;

    }
}
