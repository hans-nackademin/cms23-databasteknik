using FM.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FM.Repositories;

internal abstract class Repository<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var result = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        return result ?? null!;
    }   
}
