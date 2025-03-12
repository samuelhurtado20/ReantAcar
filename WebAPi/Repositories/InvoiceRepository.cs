using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class InvoiceRepository(ApplicationDbContext appDbContext) : Repository<Invoice>(appDbContext), IInvoiceRepository
{
}