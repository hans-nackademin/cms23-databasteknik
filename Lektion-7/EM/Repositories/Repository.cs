using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;

namespace EM.Repositories;

public abstract class Repository<TEntity> where TEntity : class
{
    private readonly string _databasePath;
    public IDbConnection Connection() => new SqliteConnection($"Data Source={_databasePath}");

    public Repository(string databasePath)
    {
        _databasePath = databasePath;
        DatabaseEnsureCreated();
    }

    private void DatabaseEnsureCreated()
    {
        try
        {
            using var connection = Connection();

            var createTables =
            @"
            CREATE TABLE IF NOT EXISTS Categories (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                CategoryName TEXT 
            );

            CREATE TABLE IF NOT EXISTS Products (
                ArticleNumber TEXT PRIMARY KEY,
                Title TEXT, 
                CategoryId INTEGER
            );
        ";

            connection.Execute(createTables);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
    }

    public virtual async Task<TEntity> CreateAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            await connection.ExecuteAsync(query, param);
            return await connection.QueryFirstOrDefaultAsync<TEntity>("SELECT last_insert_rowid()");
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryAsync<TEntity>(query, param);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null;
    }

    public virtual async Task<TEntity> GetAsync(string query, object param = null)
    {
        try
        {
            using var connection = Connection();
            return await connection.QueryFirstOrDefaultAsync(query, param);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null;
    }
}
