using EcoJardimPro.DOMAIN.Entity.All;
using System.Threading.Tasks;

namespace EcoJardimPro.SERVICE.Interface.All
{
    public interface IUsuarioService: ICrudService<Usuario>
    {
        Task Post(Usuario usuario, string dominio);
        Task<Usuario> Login(string login, string senha);
        Task AlterarSenha(long id, string senhaAntiga, string senhaNova);
        Task<bool> MudarTema(long id);
        public Usuario GerarSenha(Usuario usuario);
    }
}
