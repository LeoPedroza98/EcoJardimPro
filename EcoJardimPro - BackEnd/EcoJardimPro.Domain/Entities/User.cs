using EcoJardimPro.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoJardimPro.Domain.Entities
{
    [Table("User", Schema = "All")]
    public class User : IEntity
    {
        public long Id { get; set; }
        [MaxLength(120), Required] public string Login { get; set; }
        public string Senha { get { return null; } set { _senha = value; } }
        public DateTime DataHoraCriacao { get; set; }
        [Required] public string Name { get; set; }
        public byte[] Foto { get; set; }
        [Required] public bool Ativo { get; set; }
        public bool TemaEscuro { get; set; }
        public User()
        {
            DataHoraCriacao = DateTime.Now;
            Ativo = true;
        }

        public string GetSenha()
        {
            return _senha;
        }
        private string _senha;

    }
}
