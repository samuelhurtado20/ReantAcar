using WebAPi.Data.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class InvoiceDetailService : IInvoiceDetailService
{
    private readonly IInvoiceDetailRepository _repository;

    public InvoiceDetailService(IInvoiceDetailRepository repository)
    {
        _repository = repository;
    }

    Task<InvoiceDetail> IService<InvoiceDetail>.Create(InvoiceDetail model)
    {
        throw new NotImplementedException();
    }

    Task IService<InvoiceDetail>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<InvoiceDetail> IService<InvoiceDetail>.Edit(InvoiceDetail model)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<InvoiceDetail>> IService<InvoiceDetail>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<InvoiceDetail> IService<InvoiceDetail>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}