using Dapper;
using EM.Entities;
using EM.Models;
using System.Diagnostics;

namespace EM.Repositories;

public class ProductRepository : Repository<ProductEntity>
{
    public ProductRepository(string databasePath) : base(databasePath)
    {
    }

    public virtual async Task<IEnumerable<Product>> GetAllWithCategoryAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryAsync<Product>(query, param);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null;
    }

}
