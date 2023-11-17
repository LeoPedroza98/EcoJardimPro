using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.IdentityBase
{
    public interface ISessaoUsuario
    {
        string UsuarioId { get; set; }
        List<string> Roles { get; set; }
        string UserName { get; set; }
    }
}
