using EcoJardimProject.Domain.DTOs;

namespace EcoJardimProject.API.Services
{
    public interface ILoginService
    {
        Task<UsuarioToken> Login(LoginDTO usuario);
    }
}
