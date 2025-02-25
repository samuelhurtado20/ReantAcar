using Models.Entities;
using WebAPi.Data;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {
    }
}