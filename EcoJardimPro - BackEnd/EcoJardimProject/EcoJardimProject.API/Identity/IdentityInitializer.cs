using EcoJardimProject.Data.Context;
using EcoJardimProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcoJardimProject.API.Identity;

public class IdentityInitializer
{
    private readonly EcoJardimProjectContext _context;
    private readonly UserManager<Usuario> _userManager;
    
    public IdentityInitializer(EcoJardimProjectContext context, UserManager<Usuario> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    private async Task CreateUser(Usuario usuario, string password)
    {
        if (!_userManager.Users.IgnoreQueryFilters().Any(x => x.UserName == usuario.UserName))
        {
            var resultado = await _userManager.CreateAsync(usuario, password);

            if (!resultado.Succeeded)
                throw new InvalidOperationException($"Erro durante a criação da usuário {usuario.UserName}.");
        }

    }
    
    public async Task Initialize()
{
    List<Usuario> usuarios = new List<Usuario>
    {
        new Usuario
        {
            UserName = "leo",
            Nome = "Leonardo",
            Sobrenome = "Pedroza",
        },
        new Usuario
        {
            UserName = "armenio",
            Nome = "Armenio",
            Sobrenome = "Cardoso",
        },
    };

    foreach (var usuario in usuarios)
    {
        await CreateUser(usuario, "123@Alterar");
    }
}
}