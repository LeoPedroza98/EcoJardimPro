using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public interface IProjetoRepository : ICrudRepository<Projeto>
{
    Task<List<Projeto>> AutoComplete(string q);
}