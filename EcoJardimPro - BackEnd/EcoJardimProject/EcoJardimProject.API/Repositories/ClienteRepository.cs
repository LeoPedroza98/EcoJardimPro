using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.RepositoriesBase;
using EcoJardimProject.Domain.Entities;

namespace EcoJardimProject.API.Repositories;

public class ClienteRepository : CrudRepository<Cliente>,IClienteRepository
{
    private readonly EcoJardimProjectContext _context;
    private IMapper _mapper;


    public ClienteRepository(EcoJardimProjectContext context) : base(context)
    {
        _context = context;
    }
}