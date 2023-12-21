using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public interface IOrcamentoService : ICrudService<Orcamento>
{
    Task<List<Orcamento>> AutoComplete(string q);
}