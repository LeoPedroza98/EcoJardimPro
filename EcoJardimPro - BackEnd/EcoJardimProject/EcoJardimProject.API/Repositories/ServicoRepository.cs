using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public class ServicoRepository: CrudRepository<Servico>,IServicoRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public ServicoRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }
}