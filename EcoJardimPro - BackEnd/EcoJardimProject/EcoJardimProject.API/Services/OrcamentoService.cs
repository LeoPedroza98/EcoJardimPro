using EcoJardimProject.API.Repositories;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public class OrcamentoService: CrudService<Orcamento, IOrcamentoRepository>, IOrcamentoService
{
    private readonly IOrcamentoRepository _repository;

    public OrcamentoService(IOrcamentoRepository repository) : base(repository)
    {
        _repository = repository;
    }
}