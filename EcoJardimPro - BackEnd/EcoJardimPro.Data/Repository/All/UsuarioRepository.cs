using EcoJardimPro.DATA.Context;
using EcoJardimPro.DATA.Interface.All;
using EcoJardimPro.DOMAIN.Entity.All;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcoJardimPro.DATA.Repository.All
{
    public class UsuarioRepository : CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EcoJardimProContext context) : base(context)
        {
        }

        public override void Update(Usuario entity)
        {
            _context.Entry(entity).Property(x => x.Login).IsModified = false;

            base.Update(entity);
        }

        public async Task<Usuario> Login(string login)
        {
            var usuario = await _context.Usuarios
                    .Include(x => x.Perfil)
                    .IgnoreQueryFilters()
                    .SingleOrDefaultAsync(x => x.Login.ToUpper() == login.ToUpper());

            return usuario;
        }
    }
}
