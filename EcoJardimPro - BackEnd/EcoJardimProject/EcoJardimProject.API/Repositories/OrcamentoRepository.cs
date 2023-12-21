using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.API.Repositories;

public class OrcamentoRepository: CrudRepository<Orcamento>,IOrcamentoRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public OrcamentoRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }

     public async Task<List<Orcamento>> AutoComplete(string q)
    {
        var query = _context.Orcamentos
            .AsNoTracking()
            .Where(x =>
                x.Descricao.ToUpper().Contains(q.ToUpper()));

        return await query.ToListAsync();
    }
}