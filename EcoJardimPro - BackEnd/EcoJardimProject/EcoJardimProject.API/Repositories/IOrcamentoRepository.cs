using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public interface IOrcamentoRepository: ICrudRepository<Orcamento>
{
     Task<List<Orcamento>> AutoComplete(string q);
}