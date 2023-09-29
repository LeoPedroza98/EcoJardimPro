using System.Threading.Tasks;

namespace EcoJardimPro.SERVICE.Interface
{
    public interface IAutenticadorService
    {
        Task<object> Login(string login, string senha);
    }
}
