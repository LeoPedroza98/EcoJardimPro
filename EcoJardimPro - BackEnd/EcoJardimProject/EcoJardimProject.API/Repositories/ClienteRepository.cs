using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.API.Repositories;

public class ClienteRepository : CrudRepository<Cliente>,IClienteRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public ClienteRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Cliente>> AutoComplete(string q)
    {
        var query = _context.Clientes
            .AsNoTracking()
            .Where(x =>
                x.Nome.ToUpper().Contains(q.ToUpper()));

        return await query.ToListAsync();
    }
}