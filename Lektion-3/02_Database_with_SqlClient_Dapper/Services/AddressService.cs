using _02_Database_with_SqlClient_Dapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace _02_Database_with_SqlClient_Dapper.Services;

internal class AddressService
{
    private readonly string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\education\cms23\databasteknik\Lektion-3\02_Database_with_SqlClient_Dapper\Data\local_db_dapper.mdf;Integrated Security=True;Connect Timeout=30";

    public int CreateAddress(Address address)
    {
        try
        {
            using var conn = new SqlConnection(connectionstring);
            var result = conn.ExecuteScalar<int>("IF NOT EXISTS (SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode) INSERT INTO Addresses OUTPUT INSERTED.Id VALUES (@StreetName, @PostalCode, @City) ELSE SELECT Id FROM Addresses WHERE StreetName = @StreetName AND PostalCode = @PostalCode", address);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return 0;
    }

}
