using Models.Entities;
using WebAPi.Data;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {
    }
}