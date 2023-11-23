using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public class OrcamentoRepository: CrudRepository<Orcamento>,IOrcamentoRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public OrcamentoRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }
}