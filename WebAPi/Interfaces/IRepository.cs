using Models.Entities;
using System.Linq.Expressions;

namespace WebAPi.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T> CreateAsync(T entity);

    public Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task<T?> GetByIdIncludingAsync(int id, params Expression<Func<T, object>>[] includeProperties);

    public Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);

    public Task<T> UpdateAsync(T entity);

    public Task DeleteAsync(T entity);
}