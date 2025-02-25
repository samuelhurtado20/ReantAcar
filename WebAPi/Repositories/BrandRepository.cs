using Models.Entities;
using WebAPi.Data;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {
    }
}