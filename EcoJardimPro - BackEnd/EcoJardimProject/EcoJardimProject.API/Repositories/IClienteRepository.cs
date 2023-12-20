using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public interface IClienteRepository : ICrudRepository<Cliente>
{
    Task<List<Cliente>> AutoComplete(string q);
}