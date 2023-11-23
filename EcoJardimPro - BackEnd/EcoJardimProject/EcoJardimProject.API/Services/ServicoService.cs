using EcoJardimProject.API.Repositories;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public class ServicoService: CrudService<Servico,IServicoRepository>,IServicoService
{
    public ServicoService(IServicoRepository repository) : base(repository)
    {
    }
}