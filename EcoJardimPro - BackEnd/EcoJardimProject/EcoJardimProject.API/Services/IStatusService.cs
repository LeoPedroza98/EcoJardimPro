using EcoJardimProject.Data.ServicesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Services;

public interface IStatusService: IQueryService<Status>
{
    Task<List<Status>> AutoComplete(string q);
}