using WebAPi.Data.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class BrandService(IBrandRepository repository) : IBrandService
{
    private readonly IBrandRepository _repository = repository;

    async Task<Brand> IService<Brand>.Create(Brand model)
    {
        return await _repository.CreateAsync(model);
    }

    async Task IService<Brand>.Delete(int id)
    {
        var brand = await _repository.GetByIdAsync(id);
        if (brand?.Id != id)
        {
            throw new Exception("Invalid Id");
        }
        await _repository.DeleteAsync(brand);
    }

    async Task<Brand> IService<Brand>.Edit(Brand model)
    {
        return await _repository.UpdateAsync(model);
    }

    async Task<IEnumerable<Brand>> IService<Brand>.GetAll()
    {
        return await _repository.GetAllAsync();
    }

    async Task<Brand> IService<Brand>.GetById(int id)
    {
        return await _repository.GetByIdAsync(id) ?? new();
    }
}