using _02_VG_EntityFrameworkCore.Contexts;
using _02_VG_EntityFrameworkCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace _02_VG_EntityFrameworkCore.Repositories;

internal class ProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }



    // CREATE
    public async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        try
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }


    // READ
    public async Task<IEnumerable<ProductEntity>> ReadAsync()
    {
        try
        {
            return await _context.Products.ToListAsync();
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    public async Task<ProductEntity> ReadAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            var entity = await _context.Products.FirstOrDefaultAsync(expression);
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }


    // UPDATE
    public async Task<ProductEntity> UpdateAsync(ProductEntity entity)
    {
        try
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }

    // DELETE
    public async Task<bool> DeleteAsync(ProductEntity entity)
    {
        try
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }

    // EXISTS
    public async Task<bool> ExistsAsync(Expression<Func<ProductEntity, bool>> expression)
    {
        try
        {
            return await _context.Products.AnyAsync(expression);
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return false;
    }
}
