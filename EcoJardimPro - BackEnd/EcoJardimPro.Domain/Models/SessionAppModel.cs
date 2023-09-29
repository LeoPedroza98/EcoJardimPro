namespace EcoJardimPro.DOMAIN.Models
{
    public class SessionAppModel
    {
        public long UsuarioId { get; set; }
        public string UsuarioNome { get; }
        public string Role { get; set; }
        public string Login { get; set; }
        public byte[] UsuarioFoto { get; set; }
        public bool TemaEscuro { get; set; }

        public SessionAppModel(long usuarioId, string usuarioNome, string role, string login)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            Role = role;
            Login = login;
            TemaEscuro = false;
        }
    }
}
