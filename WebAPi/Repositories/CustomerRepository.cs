using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class CustomerRepository(ApplicationDbContext appDbContext) : Repository<Customer>(appDbContext), ICustomerRepository
{
}