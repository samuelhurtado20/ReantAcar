using Models.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    Task<Vehicle> IService<Vehicle>.Create(Vehicle model)
    {
        throw new NotImplementedException();
    }

    Task IService<Vehicle>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<Vehicle> IService<Vehicle>.Edit(Vehicle model)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Vehicle>> IService<Vehicle>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Vehicle> IService<Vehicle>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}