using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public interface IClienteService : ICrudService<Cliente>
{
    Task<List<Cliente>> AutoComplete(string q);
}