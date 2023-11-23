using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Projeto : IEntity
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public long StatusId { get; set; }
    public Status? Status { get; private set; }
    public DateTime PrazoInicial { get; set; }
    public DateTime PrazoFinal { get; set; }
    public decimal Valor { get; set; }
    public long ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}