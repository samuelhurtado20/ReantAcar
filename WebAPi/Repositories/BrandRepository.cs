using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class BrandRepository(ApplicationDbContext appDbContext) : Repository<Brand>(appDbContext), IBrandRepository
{
}