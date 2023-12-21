using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Orcamento : IEntity
{
    public long Id { get; set; }
    public string Nome {get;set;}
    public DateTime DataCriacao { get; set; }
    public string Descricao { get; set; }
    public long ProjetoId { get; set; }
    public Projeto? Projeto { get; set; }
    public List<Servico> Servicos { get; set; }
    
    public Orcamento()
    {
        Servicos = new List<Servico>();
    }
}