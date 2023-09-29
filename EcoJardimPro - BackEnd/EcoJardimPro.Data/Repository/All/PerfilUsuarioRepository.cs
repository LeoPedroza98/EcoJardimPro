using EcoJardimPro.DATA.Context;
using EcoJardimPro.DATA.Interface.All;
using EcoJardimPro.DOMAIN.Entity.All;

namespace EcoJardimPro.DATA.Repository.All
{
    public class PerfilUsuarioRepository : QueryRepository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        public PerfilUsuarioRepository(EcoJardimProContext context) : base(context)
        {
        }
    }
}
