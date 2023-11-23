using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public interface IStatusRepository: IQueryRepository<Status>
{
    Task<List<Status>> AutoComplete(string q);

}