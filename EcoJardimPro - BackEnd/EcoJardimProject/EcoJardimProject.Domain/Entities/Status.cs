using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcoJardimProject.Domain.Base;

namespace EcoJardimProject.Domain.Entities;

public class Status : IEntity
{

    [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }

    [MaxLength(60)] public string Nome { get; set; }
    
    public Status(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
    
    [NotMapped] public static Status EmAndamento => new Status(1, "Em Andamento");
    [NotMapped] public static Status EmEspera => new Status(2, "Em Espera");
    [NotMapped] public static Status AguardandoAprovacao => new Status(3, "Aguardando Aprovação");
    [NotMapped] public static Status Concluido => new Status(4, "Concluído");
    [NotMapped] public static Status Cancelado => new Status(5, "Cancelado");
    
    public static Status[] ObterDados()
    {
        return new Status[]
        {
            EmAndamento,
            EmEspera,
            AguardandoAprovacao,
            Concluido,
            Cancelado
        };
    }
}