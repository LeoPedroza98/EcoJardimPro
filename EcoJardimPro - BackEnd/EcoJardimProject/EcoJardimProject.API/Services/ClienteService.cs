using EcoJardimProject.API.Repositories;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public class ClienteService : CrudService<Cliente, IClienteRepository>, IClienteService
{
    private readonly IClienteRepository _repository;
    
    public ClienteService(IClienteRepository repository) : base(repository)
    {
        
    }

    public async Task<List<Cliente>> AutoComplete(string q)
    {
        return await _repository.AutoComplete(q);
    }
}