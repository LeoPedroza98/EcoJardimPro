using EcoJardimProject.Domain.DTOs;

namespace EcoJardimProject.API.Services
{
    public interface IUsuarioService
    {
        Task Create(UsuarioDTO usuario);
    }
}
