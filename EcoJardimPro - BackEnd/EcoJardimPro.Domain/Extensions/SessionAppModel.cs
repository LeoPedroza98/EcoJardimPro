namespace EcoJardimPro.Domain.Extensions
{
    public class SessionAppModel
    {

        public long UserId { get; set; }
        public string UserNome { get; }
        public string Role { get; set; }
        public string Login { get; set; }
        public byte[] UserFoto { get; set; }
        public bool TemaEscuro { get; set; }
        public SessionAppModel(long userId,string login, string userNome, string role )
        {
            UserId = userId;
            UserNome = userNome;
            Role = role;
            Login = login;
            TemaEscuro = false;
        }
    }
}
