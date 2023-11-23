using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.API.Repositories;

public class StatusRepository : QueryRepository<Status>,IStatusRepository
{
    public StatusRepository(EcoJardimProjectContext context) : base(context)
    {
    }
    
    public async Task<List<Status>> AutoComplete(string q)
    {
        var query = _context.Status
            .AsNoTracking()
            .Where(x =>
                x.Nome.ToUpper().Contains(q.ToUpper()));

        return await query.ToListAsync();
    }
}