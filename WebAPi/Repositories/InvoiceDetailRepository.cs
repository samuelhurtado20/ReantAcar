using Models.Entities;
using WebAPi.Data;
using WebAPi.Interfaces.Repositories;

namespace WebAPi.Repositories;

public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
{
    public InvoiceDetailRepository(ApplicationDbContext appDbContext) : base(appDbContext)
    {
    }
}