using EcoJardimProject.API.Repositories;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public class ProjetoService: CrudService<Projeto,IProjetoRepository>,IProjetoService
{
    public ProjetoService(IProjetoRepository repository) : base(repository)
    {
    }

    public async Task<List<Projeto>> AutoComplete(string q)
    {
        return await _repository.AutoComplete(q);
    }
}