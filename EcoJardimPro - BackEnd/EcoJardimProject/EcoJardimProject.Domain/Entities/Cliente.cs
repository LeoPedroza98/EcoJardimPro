using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Cliente : IEntity
{

    public long Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Documento { get; set; }
    public Endereco? Endereco { get; set; }
    public Contato? Contato { get; set; }
    public ICollection<Projeto> Projetos { get; set; }
    public Cliente()
    {
        Projetos = new List<Projeto>();
    }
}