using Models.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _repository;

    public BrandService(IBrandRepository repository)
    {
        _repository = repository;
    }

    Task<Brand> IService<Brand>.Create(Brand model)
    {
        throw new NotImplementedException();
    }

    Task IService<Brand>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<Brand> IService<Brand>.Edit(Brand model)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Brand>> IService<Brand>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Brand> IService<Brand>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}