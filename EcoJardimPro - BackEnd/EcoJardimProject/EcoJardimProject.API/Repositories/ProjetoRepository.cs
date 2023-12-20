using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.API.Repositories;

public class ProjetoRepository : CrudRepository<Projeto>, IProjetoRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public ProjetoRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Projeto>> AutoComplete(string q)
    {
        var query = _context.Projetos
            .AsNoTracking()
            .Where(x =>
                x.Nome.ToUpper().Contains(q.ToUpper()));

        return await query.ToListAsync();
    }
}