using WebAPi.Data;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class InvoiceDetailRepository(ApplicationDbContext appDbContext) : Repository<InvoiceDetail>(appDbContext), IInvoiceDetailRepository
{
}