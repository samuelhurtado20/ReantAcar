using WebAPi.Data.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    private readonly ICustomerRepository _repository = repository;

    Task<Customer> IService<Customer>.Create(Customer model)
    {
        throw new NotImplementedException();
    }

    Task IService<Customer>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<Customer> IService<Customer>.Edit(Customer model)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Customer>> IService<Customer>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Customer> IService<Customer>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}