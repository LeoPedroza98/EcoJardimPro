using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.IdentityBase
{
    public class SessaoUsuario: ISessaoUsuario
    {
        public string UsuarioId { get; set; }
        public List<string> Roles { get; set; }
        public string UserName { get; set; }
    }
}
