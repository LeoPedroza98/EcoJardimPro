using EcoJardimProject.API.Repositories;
using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public class StatusService: QueryService<Status,IStatusRepository>,IStatusService
{
    public StatusService(IStatusRepository repository) : base(repository)
    {
    }
    
    public async Task<List<Status>> AutoComplete(string q)
    {
        return await _repository.AutoComplete(q);
    }
}