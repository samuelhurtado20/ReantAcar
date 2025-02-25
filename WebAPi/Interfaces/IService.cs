using Models.Entities;

namespace WebAPi.Interfaces;

public interface IService<TModel> where TModel : BaseEntity
{
    public Task<TModel> Create(TModel model);

    public Task Delete(int id);

    public Task<TModel> Edit(TModel model);

    public Task<IEnumerable<TModel>> GetAll();

    public Task<TModel> GetById(int id);
}