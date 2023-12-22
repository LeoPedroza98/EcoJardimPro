using System.ComponentModel.DataAnnotations;
using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Servico: IEntity
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public long StatusId { get; set; }
    public Status? Status { get; set; }
    public long OrcamentoId { get; set; }
    public Orcamento? Orcamento { get; set; }
    public string? DataInicio { get; set; }
    public string? DataFinalizacao { get; set; }
}