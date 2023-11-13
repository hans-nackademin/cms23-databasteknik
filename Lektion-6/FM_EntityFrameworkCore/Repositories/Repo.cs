using FM_EntityFrameworkCore.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FM_EntityFrameworkCore.Repositories;

internal abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }

    // CREATE
    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity ?? null!;
    }

    // READ
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity,bool>> expression)
    {
        var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        return entity ?? null!;
    }

    // READ
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return entities ?? null!;
    }

    // UPDATE
    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity ?? null!;
    }

    // DELETE
    public virtual async Task<bool> DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }


    // EXISTS - Ingår inte i CRUD men är bra att ha
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        var exists = await _context.Set<TEntity>().AnyAsync(expression);
        return exists;
    }
}
