using Models.Entities;
using System.Linq.Expressions;
using WebAPi.Data;
using WebAPi.Interfaces;

namespace WebAPi.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private ApplicationDbContext _appDbContext;

    public Repository(ApplicationDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    Task<T> IRepository<T>.CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    Task IRepository<T>.DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<T>> IRepository<T>.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<T>> IRepository<T>.GetAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    Task<T?> IRepository<T>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<T?> IRepository<T>.GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    Task<T> IRepository<T>.UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}