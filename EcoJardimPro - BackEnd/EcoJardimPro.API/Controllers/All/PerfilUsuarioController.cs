using EcoJardimPro.DOMAIN.Entity.All;
using EcoJardimPro.SERVICE.Interface;
using Microsoft.Extensions.Logging;

namespace EcoJardimPro.API.Controllers.All
{
    public class PerfilUsuarioController : MasterQueryController<PerfilUsuario>
    {
        public PerfilUsuarioController(ILogger<MasterQueryController<PerfilUsuario>> logger, IQueryService<PerfilUsuario> service) : base(logger, service)
        {
        }
    }
}
