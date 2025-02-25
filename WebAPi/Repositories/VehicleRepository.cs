using Models.Entities;
using WebAPi.Data;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {
    }
}