using EcoJardimPro.DOMAIN.Entity.All;
using System.Threading.Tasks;

namespace EcoJardimPro.DATA.Interface.All
{
    public interface IUsuarioRepository : ICrudRepository<Usuario>
    {
        Task<Usuario> Login(string login);
    }
}
