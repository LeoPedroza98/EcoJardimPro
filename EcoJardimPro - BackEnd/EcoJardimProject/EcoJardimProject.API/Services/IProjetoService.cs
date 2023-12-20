using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public interface IProjetoService: ICrudService<Projeto>
{
    Task<List<Projeto>> AutoComplete(string q);
}