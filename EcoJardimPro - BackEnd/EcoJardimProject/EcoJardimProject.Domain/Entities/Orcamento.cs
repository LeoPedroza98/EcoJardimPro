using System.ComponentModel.DataAnnotations;
using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Orcamento : IEntity
{
    public long Id { get; set; }
    public string Nome {get;set;}
    [DisplayFormat(DataFormatString = "{0:MMddyyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataCriacao { get; set; }
    public string Descricao { get; set; }
    public long ProjetoId { get; set; }
    public Projeto? Projeto { get; set; }
    public ICollection<Servico> Servicos { get; set; }
    
    public Orcamento()
    {
        Servicos = new List<Servico>();
        DataCriacao = DateTime.Now;
    }
}