using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces;

namespace WebAPi.Repositories;

public class Repository<T>(ApplicationDbContext appDbContext) : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _appDbContext = appDbContext;

    async Task<T> IRepository<T>.CreateAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    async Task IRepository<T>.DeleteAsync(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    async Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }

    async Task<IEnumerable<T>> IRepository<T>.GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _appDbContext.Set<T>().Where(predicate).ToListAsync();
    }

    async Task<T?> IRepository<T>.GetByIdAsync(int id)
    {
        return await _appDbContext.Set<T>().FindAsync(id);
    }

    async Task<T?> IRepository<T>.GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = _appDbContext.Set<T>().AsQueryable();
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    async Task<T> IRepository<T>.UpdateAsync(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }
}