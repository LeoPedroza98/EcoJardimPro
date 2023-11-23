using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Servico: IEntity
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Descrição { get; set; }
    public decimal Valor { get; set; }
    public Status? Status { get; set; }
    public long OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFinalizacao { get; set; }
}