using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class VehicleRepository(ApplicationDbContext appDbContext) : Repository<Vehicle>(appDbContext), IVehicleRepository
{
}