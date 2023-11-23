using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public class ProjetoRepository : CrudRepository<Projeto>,IProjetoRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public ProjetoRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }
}