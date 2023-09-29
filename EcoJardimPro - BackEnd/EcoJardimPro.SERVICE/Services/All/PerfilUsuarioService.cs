using EcoJardimPro.DATA.Interface.All;
using EcoJardimPro.DOMAIN.Entity.All;
using EcoJardimPro.SERVICE.Interface.All;
using EcoJardimPro.SERVICE.Services;
using EcoJardimPro.SERVICE.Services.Interface.All;

namespace EcoJardimPro.Services.All
{
    public class PerfilUsuarioService : QueryService<PerfilUsuario, IPerfilUsuarioRepository>, IPerfilUsuarioService
    {
        public PerfilUsuarioService(IPerfilUsuarioRepository repository) : base(repository)
        {
        }
    }
}
