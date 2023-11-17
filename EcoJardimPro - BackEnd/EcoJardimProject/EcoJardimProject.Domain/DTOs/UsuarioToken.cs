using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoJardimProject.Domain.DTOs
{
    public class UsuarioToken
    {
        public bool Autenticado { get; set; }
        public string DataCriacao { get; set; }
        public string DataExpiracao { get; set; }
        public string TokenDeAcesso { get; set; }
        public string Mensagem { get; set; }
    }
}
