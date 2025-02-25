using Models.Entities;
using WebAPi.Interfaces;
using WebAPi.Interfaces.Repositories;
using WebAPi.Interfaces.Services;

namespace WebAPi.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _repository;

    public InvoiceService(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    Task<Invoice> IService<Invoice>.Create(Invoice model)
    {
        throw new NotImplementedException();
    }

    Task IService<Invoice>.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<Invoice> IService<Invoice>.Edit(Invoice model)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Invoice>> IService<Invoice>.GetAll()
    {
        throw new NotImplementedException();
    }

    Task<Invoice> IService<Invoice>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}